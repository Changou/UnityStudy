using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose2 : SliderBase
{
    protected override void OnSlider(float value)
    {
        Vector3 scale = _target[0].localScale;
        scale.y = value;
        _target[0].localScale = scale;

    }
}
