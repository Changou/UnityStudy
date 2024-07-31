using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTransform : MonoBehaviour
{
    [Header("위치 정보")]
    [SerializeField] Transform _pivot;
    [SerializeField] Transform _lHandle;
    [SerializeField] Transform _rHandle;

    public void SetTransform(out Transform pivot, out Transform lHandle, out Transform rHandle)
    {
        pivot = _pivot;
        lHandle = _lHandle;
        rHandle = _rHandle;
    }
}
