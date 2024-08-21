using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye2 : SliderBase
{
    protected override void OnSlider(float value)
    {
        foreach(Transform eye in _target)
        {
            eye.transform.localPosition = new Vector3(eye.transform.localPosition.x, value, eye.transform.localPosition.z);
        }
    }
}
