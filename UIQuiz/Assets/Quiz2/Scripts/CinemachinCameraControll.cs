using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CinemachinCameraControll : MonoBehaviour
{
    public static CinemachinCameraControll _Inst;

    public enum CAMERA_TYPE
    {
        ALL,
        CARSELECT,
        STARTRACE,
        CARFOLLOW,
        FINISH,

        MAX
    }

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

    public void SetTargetCamera(Transform target)
    {
        _virtualCam[(int)CAMERA_TYPE.STARTRACE].Follow = target;
        _virtualCam[(int)CAMERA_TYPE.CARFOLLOW].LookAt = target;
    }

    public void ChangeViewCarRace(int number)
    {
        CinemachineBrain.SoloCamera = _virtualCam[number];
    }
}
