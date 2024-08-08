using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] float _speed = 10f;

    [SerializeField] float _MaxRot = 90f;
    [SerializeField] float _MinRot = -90f;

    Vector3 rot;

    private void Start()
    {
        rot = Vector3.zero;
    }
    private void Update()
    {
        if (rot.z >= _MaxRot || rot.z <= _MinRot)
            _speed *= -1f;

        rot.z += _speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rot);
    }
}
