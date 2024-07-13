using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollide
{
    [Header("[효과 시간]"), SerializeField] protected float _EffectTime;

    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    public virtual void Collide(Snake snake) 
    {
        Destroy(gameObject);
    }
}
