using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("[ ÃÑ¾Ë ]")]
    [SerializeField] float _speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float amount = _speed  * Time.deltaTime;
        transform.Translate(Vector3.up * amount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
