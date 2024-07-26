using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block3 : BlockMoving
{
    bool isStart = false;

    protected override void Update()
    {
        if (isStart && transform.localPosition.x < 10)
        {
            float x = transform.localPosition.x + _speed * Time.deltaTime;
            transform.localPosition = new Vector3(x, 0, 0);
        }
    }

    public void IsOn()
    {
        isStart = true;
    }
}
