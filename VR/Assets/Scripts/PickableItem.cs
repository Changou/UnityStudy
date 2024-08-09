using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour,IInteract
{
    Collider _collider;
    public Collider _Collider => _collider;
    Rigidbody _rBody;
    public Rigidbody _RBody => _rBody;
    //--------------------------------------------
     void Awake()
    {
        _collider = transform.GetComponent<Collider>();
        _rBody = transform.GetComponent<Rigidbody>();

    }// void Awake()
    //--------------------------------------------
    public void Do_Interact(Transform target)
    {
        //  플레이어의
        //  VRCircleEx2 참조..
        QVRCircle tmpVr = target.GetComponent<QVRCircle>();

        //  현재 선택한 오브젝트가
        //  VRCircleEx2 를
        //  참조하고 있는지 체크..
        if (tmpVr._MyPick != null)
            return;

        //  오브젝트의 위치를
        //  피킹 위치로 설정..
        transform.position = tmpVr._PickingPt.position;

        //  패어런팅..
        transform.SetParent(tmpVr._PickingPt);

        //  레이케스팅이 되지 않도록
        //  컬라이더 오프..
        _collider.enabled = false;

        //  물리 작용 오프..
        //  -   이걸 끄지 않으면
        //      중력에 의해 떨어짐..
        _rBody.isKinematic = true;

        //  해당 오브젝트를
        //  플레이어가 선택한
        //  오브젝트로 설정..
        tmpVr._MyPick = this;

    }
}
