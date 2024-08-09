using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public int BoxCount
    {
        get { return transform.childCount - 1; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(transform);
            if(transform.childCount >= 6)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(null);
        }
    }
}
