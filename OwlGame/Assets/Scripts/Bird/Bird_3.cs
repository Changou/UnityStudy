using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_3 : Bird_2
{
    public override void OnCollide(Vector3 hitPos)
    {
        if(!_Owl._Invincibility)
            GameManager_2._Inst.BirdStrike();

        base.OnCollide(hitPos);
    }
}
