using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : MonoBehaviour
{
    Coroutine _downCor;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(_downCor == null)
                _downCor = StartCoroutine(Down());
        }
    }

    IEnumerator Down()
    {
        yield return null;
        while(transform.localPosition.y >= -11)
        {
            float y = transform.localPosition.y - 3f * Time.deltaTime;
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
            yield return null;
        }
    }

}
