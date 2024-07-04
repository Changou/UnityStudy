using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum TYPE
{
    POTION,
    ARMOR,
    SHOES
}

public class Item : MonoBehaviour
{
    [SerializeField] TYPE t;

    int value;
    Coroutine _destroy;

    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(0, 6);
        _destroy = StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    public string _type
    {
        get { return t.ToString(); }
    }

    public int _value
    {
        get { return value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SSL.i.Add(gameObject);
            StopCoroutine(_destroy);
        }
    }
}

