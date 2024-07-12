using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollide
{
    private void Awake()
    {
        Destroy(gameObject, 3f);
    }

    public virtual void Collide(Snake snake) { }
}
