using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Female : Character
{
    public override void Motion()
    {
        transform.GetComponent<Animator>().SetTrigger("IsFindF");
    }
}
