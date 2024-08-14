using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] float _jumpPower;

    [SerializeField] Transform _cameraTrans;

    Rigidbody _rb;

    private void Awake()
    {
        _cameraTrans = Camera.main.GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._Inst._isGameOver) return;

        if(Input.GetMouseButton(0))
        {
            MoveLook();
        }
        if(Input.GetMouseButton(1))
        {
            SpeedUp(5f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            SpeedUp(1f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_rb.velocity.y == 0)
                Jump();
        }

        if (transform.position.y <= -20f)
        {
            GameManager._Inst.GameOver(false);
            transform.position = new Vector3(0, 1, 0);
            _rb.velocity = Vector3.zero;
        }
    }
    
    void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    void SpeedUp(float speed)
    {
        _speed = speed;
    }

    void MoveLook()
    {
        Vector3 dir = _cameraTrans.forward;

        dir.y = 0f;

        transform.Translate(dir * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MoveCube"))
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MoveCube"))
        {
            transform.SetParent(null);
        }
    }

}
