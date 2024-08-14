using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IInterect
{
    public void Do_interect(Transform target)
    {
        Vector3 teleport = transform.position;

        teleport.y = 1;

        target.parent.position = teleport;

    }
}
