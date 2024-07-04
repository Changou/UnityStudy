using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] Transform target;

    private void Update()
    {
        if(StageManager.i.CurrentStage >= 2)
        {
            transform.position = target.position + offset;
        }
    }
}
