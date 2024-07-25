using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _Inst;
    //-----------------------------
    public enum eGAMESTATE
    {
        PLAY,
        PAUSE,
        END
    }
    public eGAMESTATE _eGameState = eGAMESTATE.PLAY;
    //-----------------------------
    public float _speed;    //  �̵� �ӵ�..
    public float _moveDist; //  ���� �Ÿ�..
    public int _coin;       //  ȹ���� ����..
    public int _speedDist;
    public int _changeSpeed;

    //-----------------------------
    [Header("UI �Ŵ���"), SerializeField]
    UIManager _uiManager;
    //-----------------------------
    [Header("��� ���� �Ŵ���"), SerializeField]
    Block_Loop _blockManager;
    //-----------------------------
    void Awake()
    {
        _Inst = this;
        Time.timeScale = 1f;

        _blockManager._speed = _speed;
    }
    //-----------------------------
    void Update()
    {
        if (_eGameState == eGAMESTATE.PLAY)
        {
            _moveDist += Time.deltaTime * _speed;

            _uiManager.SetText_RunDist_Main(_moveDist);

            if((int)(_moveDist / _speedDist) > _changeSpeed)
            {
                ++_speed;
                _blockManager._speed = _speed;
                _blockManager.LevelUp();
                _changeSpeed = (int)(_moveDist / _speedDist);
            }
        }
    }
    //-----------------------------
    public void GetCoin()
    {
        _coin += 1;

        _uiManager.SetText_Coin_Main(_coin);
    }
    //-----------------------------
    public void GameOver()
    {
        _uiManager.Show_Menu_Only(UIManager.eMENU.RESULT);

        _uiManager.SetText_RunDist_Result(_moveDist);

        _uiManager.SetText_Coin_Result(_coin);

        _eGameState = eGAMESTATE.END;

        Time.timeScale = 0f;
    }
    //-----------------------------
    public void SetPause()
    {
        Time.timeScale = 0f;

        _eGameState = eGAMESTATE.PAUSE;

        _uiManager.Show_PauseUI();
    }

    public void SetUnPause()
    {
        Time.timeScale = 1f;

        _eGameState = eGAMESTATE.PLAY;

        _uiManager.Show_MainUI();
    }
}
