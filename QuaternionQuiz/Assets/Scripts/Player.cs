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

    bool isMove;
    
    Vector3 _destination;
    Vector3 dir;
    Quaternion lookTarget;

    private void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out hit))
            {
                if(hit.transform.name == "Ground")
                    setDestination(hit.point);
            }
        }
        Move();
    }

    void setDestination(Vector3 dest)
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
