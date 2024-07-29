using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stage : MonoBehaviour
{
    [Header("진행 정도")]
    [SerializeField] Slider _slider;

    private void Start()
    {
        _slider.maxValue = 100 + ((StageManager._Inst._Stage - 1) * 10);
        _slider.value = 0;
    }

    void Update()
    {
        _slider.value = GameManagerS._Inst._moveDist;
        if(_slider.value == _slider.maxValue && GameManagerS._Inst._eGameState == GameManagerS.eGAMESTATE.PLAY)
        {
            StageManager._Inst.StageClear();
        }
    }
}
