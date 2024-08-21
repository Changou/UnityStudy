using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye3 : SliderBase
{
    protected override void OnSlider(float value)
    {
        foreach (Transform eye in _target)
        {
            eye.transform.localScale = new Vector3(value, value, value);
        }
    }
}
