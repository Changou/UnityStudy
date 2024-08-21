using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheck : MonoBehaviour
{
    [SerializeField] int _camNumber;

    bool isOn = false;

    private void Start()
    {
        GameManager2._Inst._GameResetEvent += () => isOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOn)
        {
            CinemachinCameraControll._Inst.ChangeViewCarRace(_camNumber);
            isOn = true;
        }
    }
}
