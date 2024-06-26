using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 5f);       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemFunction();
            Destroy(gameObject);
        }
    }
    public abstract void ItemFunction();
}
