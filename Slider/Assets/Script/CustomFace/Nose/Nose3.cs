using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose3 : SliderBase
{
    protected override void OnSlider(float value)
    {
        Vector3 scale = _target[0].localScale;
        scale.z = value;
        _target[0].localScale = scale;
    }
}
