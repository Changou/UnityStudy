using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCude : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    [SerializeField] float _delay = 3f;

    Vector3 _defaultPos;
    Vector3 _targetPos;

    bool isOn = false;

    private void Start()
    {
        _defaultPos = transform.position;
        _targetPos = transform.position;
        _targetPos.x = 0;
    }

    private void Update()
    {
        if (!isOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
            if (transform.position.x == 0)
            {
                isOn = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _defaultPos, _speed / 2 * Time.deltaTime);
            if (transform.position.x == _defaultPos.x)
            {
                isOn = false;
            }
        }
    }

}
