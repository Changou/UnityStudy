using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float bulletSpeed;
    [SerializeField] float _lifebullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * bulletSpeed);
        Destroy(gameObject, _lifebullet);
    }
}
