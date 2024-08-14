using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] public Transform[] _wayPoints;

    private void Awake()
    {
        _wayPoints = GetComponentsInChildren<Transform>();
    }


}
