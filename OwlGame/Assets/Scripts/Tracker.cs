using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [Header("[ Ʈ��ŷ�� Ÿ�� ]"), SerializeField]
    Transform _target;

    [Header("[ Ʈ��ŷ ����]"), SerializeField]
    float _damp = 5f;

    [Header("[ Ʈ��ŷ ���� �ɼ� ]"), SerializeField]
    float _offsetY = 0.1f;

    float _maxHeight;

    void Start()
    {
        _maxHeight = _target.position.y;
    }
    //--------------------------------
    void LateUpdate()
    {
        //  Ÿ�� ����..
        float targetPosY = _target.position.y;
        if (targetPosY <= _maxHeight)
            return;

        //  ��ǥ������ ����..
        float myPosY = transform.position.y;
        myPosY = Mathf.Lerp(
            myPosY,
            targetPosY,
            Time.deltaTime * _damp);

        //  ī�޶� ���� ����..
        Vector3 myPos = transform.position;
        myPos.y = myPosY - _offsetY;
        transform.position = myPos;

        //  �ִ� ���� ����..
        _maxHeight = targetPosY;

    }
}
