using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrlEX : MoveCtrl
{
    public enum eMOVE_TYPE { WAYPOINT, LOOK_AT }

    //  현재 이동 방식..
    public eMOVE_TYPE _eMoveType = eMOVE_TYPE.WAYPOINT;
    //---------------------------
    [Header("[ 카메라 트랜스폼.. ]"), SerializeField]
    Transform _camTransf;
    //---------------------------
    [Header("[ 캐릭터 컨트롤러.. ]"), SerializeField]
    CharacterController _characterCtrl;
    //---------------------------
    protected override void Awake()
    {
        base.Awake();
        _camTransf = Camera.main.GetComponent<Transform>();
        _characterCtrl = GetComponent<CharacterController>();

    }// protected override void Awake()
    //---------------------------
    void Move_By_LookAt(float speed)
    {
        //  카메라가 바라보는 방향..
        //Vector3 dir = _camTransf.TransformDirection(Vector3.forward);
        Vector3 dir = _camTransf.forward;

        //  이동..
        _characterCtrl.SimpleMove(dir * speed);

    }// void Move_By_LookAt()
    //---------------------------
    protected override void Update()
    {
        switch (_eMoveType)
        {
            case eMOVE_TYPE.WAYPOINT:
                base.Update();
                break;

            case eMOVE_TYPE.LOOK_AT:
                if (Input.GetMouseButton(0))
                {
                    float speed = _moveSpeed;
                    if (Input.GetMouseButton(1))
                        speed += 5f;

                    Move_By_LookAt(speed);
                }
                break;

        }// switch( _eMoveType )

    }
}
