using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    SphereCollider _sCollider;

    Block3 _block;

    private void Awake()
    {
        _sCollider = GetComponent<SphereCollider>();
        _block = transform.GetChild(1).GetComponent<Block3>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sCollider.enabled = false;
            _block.IsOn();
        }
    }
}
