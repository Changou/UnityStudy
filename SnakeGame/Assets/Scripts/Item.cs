using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollide
{
    [Header("[ȿ�� �ð�]"), SerializeField] protected float _EffectTime;

    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    public virtual void Collide(Snake snake) 
    {
        Destroy(gameObject);
    }
}
