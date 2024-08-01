using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed;    //	전후 이동 속도..
    public float _rotSpeed;     //	좌우 회전 속도..

    PlayerInput _playerInput;  //	플레이어 입력 담당 컴포넌트..
    Rigidbody _rigidBody;       //	리지드 바디..
    Animator _animator;         //	애니메이터..

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
        //	회전..
        Rotate();

        //	이동..
        Move();

        //	입력 값( _playerInput.Move )에 따라
        //	애니메이터의 Move 파라미터 값 변경..
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
