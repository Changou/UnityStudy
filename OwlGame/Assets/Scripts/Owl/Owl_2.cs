using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_2 : Owl
{
    //------------------------
    [Header("[ ���� üũ ]"), SerializeField]
    Transform _checkPt;
    //------------------------
    public float _moveSpeed = 8f;
    public float _jumpSpeed = 12f;
    public float _gravity = 19f;
    public float _checkDist = 0.3f;
    //------------------------
    protected Vector3 _moveDir;
    protected bool _isDead = false;
    //------------------------
    protected virtual void OnDead() { }
    //------------------------
    //  �̵� ó��..
    protected virtual void MoveOwl()
    {
        //  ȭ�� �Ʒ��� ������� üũ..
        Vector2 scrPos = Camera.main.WorldToScreenPoint(transform.position);

        if (scrPos.y < -100)
        {
            _isDead = true;

            OnDead();

            return;
        }

        //  Ű �Է�..
        float dirValue = Input.GetAxis("Horizontal");

        //  ȭ�� �¿� �����ڸ����� üũ..
        if ((dirValue < 0 && scrPos.x < 40) ||
            (dirValue > 0 && scrPos.x > Screen.width - 40))
            dirValue = 0f;

        _moveDir.x = dirValue * _moveSpeed;

        //  �߷�..
        _moveDir.y -= _gravity * Time.deltaTime;

        //  �̵�..
        transform.Translate(_moveDir * Time.deltaTime);

        //  �ִϸ��̼�..
        _anim.SetFloat("velocity", _moveDir.y);

    }// void MoveOwl()
    //------------------------
    //  �������� üũ..
    bool _isBranch = false;
    public bool _IsBranch => _isBranch;
    bool CheckBranch()
    {
        //  üũ ����Ʈ����
        //  �Ʒ��������� ����ĳ����..
        RaycastHit2D hit = Physics2D.Raycast(
            _checkPt.position,
            Vector2.down,
            _checkDist);


        _isBranch = false;
        //  ���� �� && �������� �浹..
        //  ->  ����..
        Color rayColor = Color.red;
        if (hit.collider != null &&
            _moveDir.y < 0 &&
            hit.collider.CompareTag("Branch"))
        {
            _moveDir.y = _jumpSpeed;
            _isBranch = true;
        }
        else
            rayColor = Color.blue;

        Debug.DrawRay(
            _checkPt.position,
            Vector2.down * _checkDist,
            rayColor);

        return _isBranch;

    }// protected bool CheckBranch()
    //------------------------
    protected override void Update()
    {
        if (_isDead)
            return;

        CheckBranch();
        MoveOwl();
    }
}
