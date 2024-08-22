using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : SliderBase
{
    protected override void OnSlider(float value)
    {
        for (int i = 0; i < _target.Length; i++)
        {
            Vector3 scale = _target[i].localScale;
            scale.x = value;
            _target[i].localScale = scale;
        }
    }
}
