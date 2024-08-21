using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    [SerializeField] float _slowTime;

    bool _isOn = false;

    private void Start()
    {
        GameManager2._Inst._GameResetEvent += () => _isOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isOn)
        {
            Time.timeScale = _slowTime;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            CinemachinCameraControll._Inst.ChangeViewCam(4);
            _isOn = true;
        }
    }
}
