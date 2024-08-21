using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBase : MonoBehaviour
{
    [SerializeField] protected Transform[] _target;
    [SerializeField] Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener(OnSlider);
    }

    protected virtual void OnSlider(float value) { }
}
