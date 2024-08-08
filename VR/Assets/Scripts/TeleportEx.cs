using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEx : MonoBehaviour,IInteract
{
    public void Do_Interact(Transform target)
    {

        target.position = new Vector3(
            transform.position.x,
            transform.position.y + 1.5f,
            transform.position.z);

    }
}
