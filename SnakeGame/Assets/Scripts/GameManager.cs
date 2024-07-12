using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("[ 뱀 ]"), SerializeField]
    Snake _snake;

    [Header("[ 게임 오버 UI ]"), SerializeField]
    UI_GameOver _uiGameOver;

    [Header("[ 게임 정보 UI ]"), SerializeField]
    UI_Info _uiInfo;

    float _startTime;

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
        _uiGameOver.gameObject.SetActive(false);
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(_snake._IsDead) return;
        SetTime();
    }
}
