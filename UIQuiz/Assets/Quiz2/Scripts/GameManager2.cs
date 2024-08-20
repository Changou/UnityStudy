using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 _Inst;

    void Awake()
    {
        _Inst = this;
        CinemachinCameraControll._Inst.ChangeViewCam(0);
    }

    public CAR_TYPE _selectCar;

    public List<CAR_TYPE> _carRanks = new List<CAR_TYPE>();
}
