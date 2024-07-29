using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Rot : MonoBehaviour
{
    [SerializeField] float _speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -(_speed*Time.deltaTime)));
    }
}
