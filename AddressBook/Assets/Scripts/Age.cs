using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Age : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] Text _age;

    private void OnEnable()
    {
        _slider.value = _slider.minValue;
    }

    private void Update()
    {
        _age.text = ((int)_slider.value).ToString();
    }
}
