using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake2 : Snake
{
    [Header("[ ���� ���� UI ]"), SerializeField]
    UI_GameOver _uiGameOver;

    public override void Dead()
    {
        _isDead = true;
        if(!GameManager.i._IsGameOver)
            _uiGameOver?.gameObject.SetActive(true);
    }

}
