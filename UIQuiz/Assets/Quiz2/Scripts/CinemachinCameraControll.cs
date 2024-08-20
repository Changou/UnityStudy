using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachinCameraControll : MonoBehaviour
{
    public static CinemachinCameraControll _Inst;

    private void Awake()
    {
        _Inst = this;
    }

    [SerializeField] CinemachineVirtualCamera[] _virtualCam;

    public void ChangeViewCam(int camNumber)
    {
        for(int i = 0; i < _virtualCam.Length; i++)
        {
            if (i == camNumber)
                _virtualCam[i].Priority = 11;
            else
                _virtualCam[i].Priority = 10;
        }
    }

    public void ChangeViewCarRace(int number)
    {
        CinemachineBrain.SoloCamera = _virtualCam[number];
    }
}
