using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ResultS : UI_Main
{
    [SerializeField] GameObject _buttonOver;
    [SerializeField] GameObject _buttonClear;

    private void Awake()
    {
        if (StageManager._Inst._IsStageClear)
        {
            _buttonOver.SetActive(false);
            _buttonClear.SetActive(true);
        }
        else
        {
            _buttonOver.SetActive(true);
            _buttonClear.SetActive(false);
        }
    }
}