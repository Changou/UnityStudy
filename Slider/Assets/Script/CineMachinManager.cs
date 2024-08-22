using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachinManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] _virCam;

    public void Show_Camera(int num)
    {
        for (int i = 0; i < _virCam.Length; i++) 
        {
            if(i == num)
            {
                _virCam[i].Priority = 11;
            }
            else
                _virCam[i].Priority = 10;
        }
    }
}
