using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : Arm
{
    Vector3 _prevScale2;

    protected override void Start()
    {
        base.Start();
        _prevScale2 = transform.localScale;
    }

    protected override void BodyCheck()
    {
        if (_prevScale != _body.localScale)
        {
            float y = _body.localScale.y - _prevScale.y;

            Vector3 pos1 = transform.localPosition;
            pos1.y -= y;
            transform.localPosition = pos1;
        }
        _prevScale = _body.localScale;

        if(_prevScale2 != transform.localScale)
        {
            float y = transform.localScale.y - _prevScale2.y;

            Vector3 pos1 = transform.localPosition;
            pos1.y -= y/2;
            transform.localPosition = pos1;
        }
        _prevScale2 = transform.localScale;
    }
}
