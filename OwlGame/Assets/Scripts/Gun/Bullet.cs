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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            collision.transform.localEulerAngles = new Vector3(0, 0, 180f);
            collision.GetComponent<Animator>().enabled = false;
            Destroy(collision.GetComponent<Collider2D>());
            collision.GetComponent<Rigidbody2D>().gravityScale = 1f;
            _speed = 0f;
            Destroy(gameObject);
        }
    }
}
