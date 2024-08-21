using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye1 : SliderBase
{
    protected override void OnSlider(float value)
    {
        float val = value;
        Vector3 pos1 = _target[0].localPosition;
        Vector3 pos2 = _target[1].localPosition;

        pos1.x = -val;
        pos2.x = val;

        _target[0].localPosition = pos1;
        _target[1].localPosition = pos2;
    }
}
