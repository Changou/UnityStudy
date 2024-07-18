using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Input_2 : UIPanel_Input
{
    float _btnAxis = 0f;
    float _dir = 0f;
    public float _BtnDir => _btnAxis;
    public void ResetDir() { _btnAxis = 0f; }
    public float _controlDamp = 2f;
    //---------------------------
    public override void OnBttnPress(int bttnType)
    {
        switch (bttnType)
        {
            case 0:
                _dir = -1;
                StartCoroutine(CRT_BttnDir());
                break;

            case 1:
                _dir = 1;
                StartCoroutine(CRT_BttnDir());
                break;

        }// switch( eBttnType )

    }// public void OnBttnPress( eBTTNDIR eBttnType )
    //---------------------------
    public override void OnBttnUp()
    {
        _dir = 0f;
        StartCoroutine(CRT_BttnDir());
    }
    //---------------------------
    IEnumerator CRT_BttnDir()
    {
        while (true)
        {
            float damp = _controlDamp;

            if (_dir == 0f)
                damp *= 0.5f;

            //  버튼을 뗐을때 0에 근접하면
            //  보간 중지..
            if (_dir == 0 && Mathf.Abs(_btnAxis) < 0.01f)
                yield break;

            //  결과 값의 오차가
            //  0.01미만이면
            //  보간 중지..
            if (Mathf.Abs(_dir) - Mathf.Abs(_btnAxis) < 0.01f)
                yield break;

            _btnAxis = Mathf.Lerp(_btnAxis, _dir, damp * Time.deltaTime);

            yield return new WaitForFixedUpdate();

        }// while( true )

    }
}
