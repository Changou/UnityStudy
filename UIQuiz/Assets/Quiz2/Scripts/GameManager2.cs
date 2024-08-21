using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 _Inst;

    void Awake()
    {
        _Inst = this;
        _GameResetEvent += () => {
            UIManager2._Inst.Only_Show_UI(UIManager2.UI.START);
            CinemachinCameraControll._Inst.ChangeViewCam(0);
            _carRanks.Clear();
        };
    }

    public CAR_TYPE _selectCar;

    public List<CAR_TYPE> _carRanks = new List<CAR_TYPE>();

    public Action _GameResetEvent;

    public void GameReset()
    {
        _GameResetEvent();
    }
}
