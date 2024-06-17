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

    [SerializeField] float max;
    [SerializeField] float min;

    float tmp_max;
    float tmp_min;

    Vector3 dir;
    Quaternion lookTarget;
    Renderer monsterColor;
    Color mineColor;

    Coroutine reversalCor;

    bool isReversal = false;
    bool isMove = true;

    private void Awake()
    {
        tmp_max = max;
        tmp_min = min;
        _target = GameObject.Find("Player").GetComponent<Transform>();
        isReversal = false;
        isMove = true;
        switch (StageManager.i.CurrentStage)
        {
            case 1:
                break;
            case 2:
                tmp_max *= 3;
                tmp_min *= 3;
                break;
            case 3:
                tmp_max *= 4;
                tmp_min *= 4;
                break;
        }
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
        
        if (transform.position.x >= tmp_max)
        {
            transform.position = new Vector3(tmp_max, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= tmp_min)
        {
            transform.position = new Vector3(tmp_min, transform.position.y, transform.position.z);
        }
        if (transform.position.z >= tmp_max)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, tmp_max);
        }
        else if (transform.position.z <= tmp_min)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, tmp_min);
        }
    }
}
