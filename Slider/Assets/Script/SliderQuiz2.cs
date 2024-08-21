using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderQuiz2 : SliderQuiz
{
    protected override void OnSlide(float value)
    {
        _target.transform.rotation = Quaternion.Euler(0, value, 0);
    }
}
