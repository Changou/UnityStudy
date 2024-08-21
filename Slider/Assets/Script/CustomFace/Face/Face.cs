using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : SliderBase
{
    protected override void OnSlider(float value)
    {
        Vector3 scale = _target[0].localScale;
        scale.x = value;
        _target[0].localScale = scale;
    }
}
