using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCircleEx : VRCircle
{
    //----------------------------------
    [Header("[ VR 카메라 ]"), SerializeField]
    Camera _vrCam;
    //----------------------------------
    [Header("[ 레티클 포인터 ]"), SerializeField]
    GvrReticlePointer _gvrReticlePt;
    //  레티클 범위..
    float _reticleDist;
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
            Transform hitTransf = _hit.transform;

            if (_ReticleRate == 1f && hitTransf.CompareTag("Teleport"))
            {
                hitTransf.gameObject.GetComponent<Teleport>().Teleport_Here(transform);
                Reset_Reticle();
            }

        }// if( Physics.Raycast( ray, out _hit, _reticleDist ))

    }
}
