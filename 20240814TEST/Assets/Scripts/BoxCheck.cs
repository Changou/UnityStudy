using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    List<GameObject> _box = new List<GameObject>();

    public int _Count
    {
        get { return _box.Count; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Box") && !_box.Contains(collision.gameObject))
        {
            _box.Add(collision.gameObject);
        }
    }
}
