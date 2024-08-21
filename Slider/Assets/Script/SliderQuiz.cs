using UnityEngine;
using UnityEngine.UI;

public class SliderQuiz : MonoBehaviour
{
    [SerializeField] protected GameObject _target;
    [SerializeField] protected Slider _slider;

    private void Start()
    {
        _slider.onValueChanged.AddListener(OnSlide);
    }

    protected virtual void OnSlide(float value)
    {
        Vector3 pos = _target.transform.position;
        pos.x = value;
        _target.transform.position = pos;
    }
}
