using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    [Header("타겟"), SerializeField] Transform _target;
    [Header("회전속도"), SerializeField] float turnSpeed;
    [Header("몬스터속도"), SerializeField] float monSpeed;
    [Header("스턴시간"), SerializeField] float stunTime;

    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxZ;
    [SerializeField] float minZ;

    Vector3 dir;
    Quaternion lookTarget;
    Renderer monsterColor;
    Color mineColor;

    Coroutine reversalCor;

    bool isReversal = false;
    bool isMove = true;

    private void Awake()
    {
        _target = GameObject.Find("Player").GetComponent<Transform>();
        isReversal = false;
        isMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        monsterColor = GetComponent<Renderer>();
        mineColor = monsterColor.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isReversal)
            {
                Debug.Log("스턴");
                StartCoroutine(Stun());
            }
            else
                GameManager.i.GameOver();
        }

    }

    IEnumerator Stun()
    {
        isMove = false;
        monsterColor.material.color = Color.white;
        yield return new WaitForSeconds(stunTime);
        monsterColor.material.color = isReversal ? Color.magenta : mineColor;
        isMove = true;
    }

    public void StartReversal()
    {
        if(reversalCor != null)
            StopCoroutine(reversalCor);
        reversalCor = StartCoroutine(Reversal());
    }

    IEnumerator Reversal()
    {
        isReversal = true;
        monsterColor.material.color = Color.magenta;
        yield return new WaitForSeconds(5f);
        monsterColor.material.color = mineColor;
        isReversal = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.i.isGameOver)
        {
            if (isMove)
            {
                Move(_target.position);
            }
        }
    }


    private void Move(Vector3 target)
    {
        dir = target - transform.position;
        if (isReversal)
        {
            dir *= -1;
        }
        lookTarget = Quaternion.LookRotation(dir);
        transform.position += dir.normalized * Time.deltaTime * monSpeed;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, turnSpeed);
        NoEntry();
    }
    void NoEntry()
    {
        if (transform.position.x >= maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        if (transform.position.z >= maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }
        else if (transform.position.z <= minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
    }
}
