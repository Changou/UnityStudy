using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_4 : Owl_3
{    
    protected override void OnDead()
    {
        GameManager_2._Inst.Set_GameOver();
    }
}
