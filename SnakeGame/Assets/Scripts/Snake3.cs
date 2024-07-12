using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake3 : Snake2
{
    [Header("[ 조이스틱 패널 ]"), SerializeField]
    GameObject _panelJoystick;
    JoyStick _joyStick;
    public bool _isMobile = false;
    //----------------------------
    [Header("[ 게임 정보 UI ]"), SerializeField]
    UI_Info _uiInfo;

    protected override void InitData()
    {
        if(_isMobile == false)
            _panelJoystick.SetActive(false);
        else
            _joyStick = _panelJoystick.GetComponent<JoyStick>();

        _coin = 0;
    }
    protected override void MoveHead()
    {
        if(_isMobile == false)
            base.MoveHead();
        else
        {
            //  이동..
            float amount = _speedMove * Time.deltaTime;
            transform.Translate(Vector3.forward * amount);

            //  회전..
            amount = _joyStick._Horizon * _speedRot;

            transform.Rotate(Vector3.up * amount * Time.deltaTime);
        }
    }
    int _coin;

    public override void AddTail()
    {
        base.AddTail();

        ++_coin;

        _uiInfo.Set_Coin(_coin);
    }
}
