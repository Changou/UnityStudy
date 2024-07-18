using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift_3 : Gift_2
{
    //----------------------------------
    public override void OnCollide(Vector3 hitPos)
    {
        base.OnCollide(hitPos);

        GameManager_2._Inst.Get_Gift(_idx);

    }
}
