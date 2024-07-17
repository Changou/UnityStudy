using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [Header("[ 트래킹할 타겟 ]"), SerializeField]
    Transform _target;

    [Header("[ 트래킹 비율]"), SerializeField]
    float _damp = 5f;

    [Header("[ 트래킹 높이 옵셋 ]"), SerializeField]
    float _offsetY = 0.1f;

    float _maxHeight;

    void Start()
    {
        _maxHeight = _target.position.y;
    }
    //--------------------------------
    void LateUpdate()
    {
        //  타겟 높이..
        float targetPosY = _target.position.y;
        if (targetPosY <= _maxHeight)
            return;

        //  목표값까지 보간..
        float myPosY = transform.position.y;
        myPosY = Mathf.Lerp(
            myPosY,
            targetPosY,
            Time.deltaTime * _damp);

        //  카메라 높이 조정..
        Vector3 myPos = transform.position;
        myPos.y = myPosY - _offsetY;
        transform.position = myPos;

        //  최대 높이 갱신..
        _maxHeight = targetPosY;

    }
}
