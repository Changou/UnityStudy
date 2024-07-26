using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoving : MonoBehaviour
{
    float _dir = 1f;
    [SerializeField] protected float _speed;

    protected virtual void Update()
    {
        if (transform.localPosition.y > 2 || transform.localPosition.y < -2)
        {
            _dir *= -1;
        }
        float y = transform.localPosition.y + (_dir * _speed * Time.deltaTime);
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }
}
