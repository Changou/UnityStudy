using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject _target;

    [Header("카메라위치")]
    [SerializeField] float offsetX = 0f;
    [SerializeField] float offsetY = 8f;
    [SerializeField] float offsetZ = -4f;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(
                _target.transform.position.x + offsetX,
                _target.transform.position.y + offsetY,
                _target.transform.position.z + offsetZ
                );
        transform.position = targetPos;
    }
}
