using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    List<GameObject> boxs = new List<GameObject>();

    public int BoxCount
    {
        get { return boxs.Count; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            if(!boxs.Contains(collision.gameObject)) 
                boxs.Add(collision.gameObject);
        }
    }
}
