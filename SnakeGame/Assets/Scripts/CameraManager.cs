using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 defaultRot;

    [Header("스테이지3")]
    [SerializeField] Vector3 offsetS3;
    [SerializeField] Vector3 cameraRotS3;
    private void Awake()
    {
        target = GameObject.Find("Snake").GetComponent<Transform>();
    }

    private void Start()
    {
        if (StageManager.i._CurrentStage == 3)
        {
            transform.SetParent(target);
            transform.localPosition = offsetS3;
            transform.rotation = Quaternion.Euler(cameraRotS3);
        }
        else
        {
            transform.position = offset;
            transform.rotation = Quaternion.Euler(defaultRot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(StageManager.i._CurrentStage == 2)
            ChaseTarget(); 
    }

    void ChaseTarget()
    {
        transform.position = target.position + offset;
    }
}
