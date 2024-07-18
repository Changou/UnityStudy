using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_5 : Owl_4
{
    protected override void MoveOwl()
    {
        //  화면 아래를 벗어났는지 체크..
        Vector2 scrPos = Camera.main.WorldToScreenPoint(transform.position);
        if (scrPos.y < -100)
        {
            _isDead = true;

            OnDead();

            return;
        }

        //  키 입력..
        float dirValue = Input.GetAxis("Horizontal");

        if (GameManager_2._Inst._IsMobile)
            dirValue = (float)GameManager_2._Inst._UIManager._GetDir;

        //  화면 좌우 가장자리인지 체크..
        if ((dirValue < 0 && scrPos.x < 40) ||
            (dirValue > 0 && scrPos.x > Screen.width - 40))
            dirValue = 0f;

        _moveDir.x = dirValue * _moveSpeed;

        //  중력..
        _moveDir.y -= _gravity * Time.deltaTime;

        //  이동..
        transform.Translate(_moveDir * Time.deltaTime);

        //  애니메이션..
        _anim.SetFloat("velocity", _moveDir.y);
    }
}
