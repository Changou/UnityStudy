using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [Header("[ ÀÚµ¿ ¹ß»ç ÃÑ ]")]
    [SerializeField] GameObject[] _guns;

    public void GunActive(int cnt)
    {
        _guns[cnt - 1].SetActive(true);
    }
}
