using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("캐릭터 속도"), SerializeField] float speed;
    [Header("회전속도"), SerializeField] float turnSpeed;

    Camera _camera;
    float tmp_speed;
    bool isMove;
    
    Vector3 _destination;
    Vector3 dir;
    Quaternion lookTarget;
    Renderer playerColor;
    Color mineColor;

    Coroutine speedCor;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        playerColor = GetComponent<Renderer>();
        mineColor = playerColor.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out hit))
            {
                if(hit.transform.gameObject.CompareTag("Ground"))
                    SetDestination(hit.point);
            }
        }
        Move();
    }

    public void SpeedUp()
    {
        if (speedCor != null)
        {
            StopCoroutine(speedCor);
            speed = tmp_speed;
        }
        speedCor = StartCoroutine(ReturnSpeed());
    }
    IEnumerator ReturnSpeed()
    {
        tmp_speed = speed;
        speed += 2;
        playerColor.material.color = Color.blue;
        yield return new WaitForSeconds(3f);
        playerColor.material.color = mineColor;
        speed = tmp_speed;
    }
    void SetDestination(Vector3 dest)
    {
        _destination = new Vector3(dest.x, transform.position.y, dest.z);
        dir = _destination - transform.position;
        lookTarget = Quaternion.LookRotation(dir);
        isMove = true;
    }

    private void Move()
    {
        if (GameManager.i.isGameOver)
        {
            if (isMove)
            {
                if (Vector3.Distance(_destination, transform.position) <= 0.1f)
                {
                    isMove = false;
                    return;
                }
                var dir = _destination - transform.position;
                transform.position += dir.normalized * Time.deltaTime * speed;
                transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, turnSpeed);
            }
        }
    }
}
