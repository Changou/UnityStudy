using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse2 : SliderBase
{
    protected override void OnSlider(float value)
    {
        Vector3 pos = _target[0].localPosition;
        pos.y = -value;
        _target[0].localPosition = pos;
    }
}
