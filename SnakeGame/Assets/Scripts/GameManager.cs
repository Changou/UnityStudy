using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    [Header("[ 뱀 ]"), SerializeField]
    Snake _snake;

    [Header("[ 게임 오버 UI ]"), SerializeField]
    UI_GameOver _uiGameOver;

    [Header("[ 게임 정보 UI ]"), SerializeField]
    UI_Info _uiInfo;

    [Header("[ 게임 클리어 UI ]"), SerializeField]
    UI_Clear _uiClear;

    float _startTime;

    public bool _IsGameOver = false;

    void SetTime()
    {
        float span = Time.time - _startTime;

        int hour = Mathf.FloorToInt(span / 3600);
        int min = Mathf.FloorToInt(span / 60 % 60);
        float sec = span % 60;

        _uiInfo.Set_PlayTime(hour, min, sec);
    }

    private void Awake()
    {
        i = this;
        _uiGameOver.gameObject.SetActive(false);
        _uiClear.gameObject.SetActive(false);
        _startTime = Time.time;
        StageManager.i.SetStage();
        _uiInfo.Set_Stage();
    }

    // Update is called once per frame
    void Update()
    {
        if(_snake._IsDead) return;
        SetTime();
    }
    public void IsGameClear(int coin)
    {
        if(coin >= 10)
        {
            _uiClear.gameObject.SetActive(true);
            if (StageManager.i._CurrentStage == 3)
            {
                _uiClear.transform.GetChild(1).gameObject.SetActive(false);
            }
            _IsGameOver = true;
            _snake.Dead();
        }
    }
}
