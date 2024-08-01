using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed;    //	���� �̵� �ӵ�..
    public float _rotSpeed;     //	�¿� ȸ�� �ӵ�..

    PlayerInput _playerInput;  //	�÷��̾� �Է� ��� ������Ʈ..
    Rigidbody _rigidBody;       //	������ �ٵ�..
    Animator _animator;         //	�ִϸ�����..

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //	ȸ��..
        Rotate();

        //	�̵�..
        Move();

        //	�Է� ��( _playerInput.Move )�� ����
        //	�ִϸ������� Move �Ķ���� �� ����..
        _animator.SetFloat("Move", _playerInput.Move);
    }

    private void Move()
    {
        Vector3 moveDist
            = _playerInput.Move
            * transform.forward
            * _moveSpeed
            * Time.deltaTime;

        _rigidBody.MovePosition(_rigidBody.position + moveDist);
    }

    void Rotate()
    {
        float turn
            = _playerInput.Rotate
            * _rotSpeed
            * Time.deltaTime;

        _rigidBody.rotation *= Quaternion.Euler(0, turn, 0);

        Debug.Log(_rigidBody.rotation.ToString());
    }
}
