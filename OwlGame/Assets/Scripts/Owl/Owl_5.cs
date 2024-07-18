using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_5 : Owl_4
{
    protected override void MoveOwl()
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

        if (GameManager_2._Inst._IsMobile)
            dirValue = (float)GameManager_2._Inst._UIManager._GetDir;

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
    }
}
