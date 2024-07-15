using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Info : MonoBehaviour
{
    [Header("[ ���� ���� ]"), SerializeField]
    TextMeshProUGUI _coin;

    public void Set_Coin(int coin)
    {
        _coin.text = $"Coin : {coin}";
    }
    [Header("[ ��� �ð� ]"), SerializeField]
    TextMeshProUGUI _playTime;
    public void Set_PlayTime(int hour, int min, float sec)
    {
        string time = "Time : {0:0} : {1:0} : {2:00.0}";
        _playTime.text = string.Format(time, hour, min, sec);
    }
    [Header("[ �������� ]"), SerializeField]
    TextMeshProUGUI _stage;

    public void Set_Stage()
    {
        _stage.text = "Stage : " + StageManager.i._CurrentStage;
    }
}
