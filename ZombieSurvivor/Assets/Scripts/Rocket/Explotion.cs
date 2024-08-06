using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    [SerializeField] Rocket _rocket;

    private void Awake()
    {
        _rocket = GetComponentInParent<Rocket>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();

        if(target != null && !other.CompareTag("Player"))
        {
            _rocket.Damage(target, other.transform.position);
            
        }
        
        Destroy(gameObject, 1f);
    }
}
