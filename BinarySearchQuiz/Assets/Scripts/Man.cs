using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : Character
{
    public override void Motion()
    {
        transform.GetComponent<Animator>().SetTrigger("IsFind");
    }
}
