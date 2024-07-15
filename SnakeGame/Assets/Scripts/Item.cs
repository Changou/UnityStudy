using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollide
{
    [Header("[효과 시간]"), SerializeField] protected float _EffectTime;
    [SerializeField] protected GameObject obj;

    private void Awake()
    {
        Destroy(obj, 8f);
    }

    public virtual void Collide(Snake snake) 
    {
        Destroy(obj);
    }
}
