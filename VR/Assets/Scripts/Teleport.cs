using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public void Teleport_Here(Transform target)
    {
        target.position = new Vector3(
            transform.position.x,
            transform.position.y + 1.5f,
            transform.position.z);

    }
}
