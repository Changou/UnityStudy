using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderQuiz3 : SliderQuiz
{
    protected override void OnSlide(float value)
    {
        Vector3 scale = new Vector3(value, value, value);
        _target.transform.localScale = scale;
    }
}
