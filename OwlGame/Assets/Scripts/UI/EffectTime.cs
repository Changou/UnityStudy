using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectTime : MonoBehaviour
{
    [SerializeField] Image _img;
    [SerializeField] Slider _timeS;
    [SerializeField] UIPanel_EffectTime _EffectTime;

    private void Awake()
    {
        _EffectTime = GameObject.Find("Panel - EffectTime").GetComponent<UIPanel_EffectTime>();
    }

    IEnumerator Timer(float time)
    {
        while (time > 0)
        {
            time -= 0.1f;
            _timeS.value = time;
            yield return new WaitForSeconds(0.1f);
        }
        _EffectTime.Remove(gameObject);
;        yield return null;
    }

    public void Setting(Sprite img, float time)
    {
        _img.sprite = img;
        _timeS.maxValue = time;
        _timeS.value = time;
        StartCoroutine(Timer(time));
        Destroy(gameObject, time + 0.2f);
    }
}
