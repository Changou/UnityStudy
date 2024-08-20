using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectToggle : MonoBehaviour
{
    [SerializeField] ToggleGroup _tg;
    [SerializeField] Toggle _reT;

    public void ToggleSelectBtn()
    {
        Toggle t = _tg.GetFirstActiveToggle();
        if (t.CompareTag("1"))
        {
            GameManager._Inst._maxGameCnt = 1;
        }
        else if (t.CompareTag("3"))
        {
            GameManager._Inst._maxGameCnt = 3;
        }
        else if (t.CompareTag("5"))
        {
            GameManager._Inst._maxGameCnt = 5;
        }
        if (_reT.isOn)
        {
            GameManager._Inst._isRestartOn = true;
        }
        else
            GameManager._Inst._isRestartOn = false;

        UIManager._Inst.Only_Show_UI(UIManager.UI.GAME);
    }
}
