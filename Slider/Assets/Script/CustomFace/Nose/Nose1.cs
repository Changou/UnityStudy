using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose1 : SliderBase
{
    protected override void OnSlider(float value)
    {
        Vector3 pos = new Vector3(0, -value, _target[0].localPosition.z);
        _target[0].localPosition = pos;
    }
}
