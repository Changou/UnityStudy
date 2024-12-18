﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCircleEx2 : VRCircle
{
    //----------------------------------
    [Header("[ VR 카메라.. ]"), SerializeField]
    Camera _vrCam;
    //----------------------------------
    [Header("[ 레티클 포인터.. ]"), SerializeField]
    GvrReticlePointer _gvrReticlePt;
    //  레티클 범위..
    float _reticleDist;
    //----------------------------------
    [Header("[ 픽킹 포인트.. ]"), SerializeField]
    Transform _transfPickingPt;
    public Transform _PickingPt => _transfPickingPt;
    //----------------------------------
    [Header("[ 픽킹한 오브젝트.. ]"), SerializeField]
    PickableItem _myPick;
    public PickableItem _MyPick
    {
        get { return _myPick; }
        set { if (_myPick == null) _myPick = value; }
    }
    //----------------------------------
    RaycastHit _hit;
    //----------------------------------
    private void Awake()
    {
        _reticleDist = _gvrReticlePt.maxReticleDistance;
    }
    //----------------------------------
    protected override void Update()
    {
        base.Update();

        Ray ray = _vrCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, _reticleDist))
        {
            if (_ReticleRate == 1f)
            {
                //  iInteract를 상속한 컴포넌트를
                //  구현했다면  Do_Interact()에 대한
                //  메시지에 대해 응답이 가능하다는
                //  신뢰 가능..

                //  -   인터페이스 문법의 특성상
                //      Do_Interact()를
                //      재정의 하지 않으면
                //      에러 발생..
                IInteract iInteract = _hit.transform.GetComponent<IInteract>();
                if (iInteract != null)
                    iInteract.Do_Interact(transform);

                Reset_Reticle();

            }// if(_ReticleRate == 1f)

        }// if( Physics.Raycast( ray, out _hit, _reticleDist ))

        if (_MyPick != null)
        {
            //  스페이스를 누르면 앞으로 던짐..
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _myPick._Collider.enabled = true;

                //  키네마틱을 꺼줘야
                //  물리력 적용..
                _myPick._RBody.isKinematic = false;

                //  전방 상단으로
                //  50의 힘 적용..
                _myPick._RBody.AddForce((_vrCam.transform.forward + _vrCam.transform.up) * 50f);

                //  페어런팅 오프..
                _myPick.transform.SetParent(null);

                //  선택한 오브젝트 해제..
                _myPick = null;

            }// if( Input.GetKeyDown( KeyCode.Space ))

        }// if( _MyPick != null )

    }
}
