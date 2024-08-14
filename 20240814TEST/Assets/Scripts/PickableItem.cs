using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using UnityEngine;

public class PickableItem : MonoBehaviour,IInterect
{
    public Rigidbody _rb;
    public Collider _coll;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _coll = GetComponent<Collider>();
    }

    public void Do_interect(Transform target)
    {
        VRCircle tmVr = target.GetComponent<VRCircle>();

        if (tmVr._myPick == null)
        {
            transform.position = tmVr._PickPoint.position;

            transform.SetParent(tmVr._PickPoint);

            tmVr._myPick = this;

            _rb.isKinematic = true;

            _coll.enabled = false;
        }
    }
}
