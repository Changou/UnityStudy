using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Vector3 _mytrans;
    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _mytrans = transform.position;
        _mytrans.y = 0.5f;
    }

    void Update()
    {
        if(transform.position.y <= -20f && transform.parent == null)
        {
            ReTrans();
        }
    }

    void ReTrans()
    {
        _rb.velocity = Vector3.zero;
        transform.position = _mytrans;
    }
}
