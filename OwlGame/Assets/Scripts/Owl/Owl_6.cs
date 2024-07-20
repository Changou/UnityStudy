using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_6 : Owl_5
{
    [Header("[ ���� ]"), SerializeField] bool _invincibility;
    [SerializeField] GameObject _Shield;
    public bool _Invincibility => _invincibility;

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
        {
            UIManager_2 uiManager = GameManager_2._Inst._UIManager as UIManager_2;
            dirValue = uiManager.GetDir();
        }

        //  ȭ�� �¿� �����ڸ����� üũ..
        if ((dirValue < 0 && scrPos.x < 40) ||
            (dirValue > 0 && scrPos.x > Screen.width - 40))
            dirValue = 0f;

        if (_IsBranch)
        {
            dirValue = 0f;
            UIManager_2 uiManager = GameManager_2._Inst._UIManager as UIManager_2;
            uiManager.ResetDir();
        }

        _moveDir.x = dirValue * (_moveSpeed + ItemManager.i._MovingEffect);

        //  �߷�..
        _moveDir.y -= _gravity * Time.deltaTime;

        //  �̵�..
        transform.Translate(_moveDir * Time.deltaTime);

        //  �ִϸ��̼�..
        _anim.SetFloat("velocity", _moveDir.y);

    }

    public void Invincibility(float time)
    {
        _invincibility = true;
        _Shield.SetActive(true);
        StartCoroutine(InVTime(time));
    }
    IEnumerator InVTime(float time)
    {
        yield return new WaitForSeconds(time);
        _Shield.SetActive(false);
        _invincibility = false;
    }

}
