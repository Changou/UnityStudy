using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPanel_Info : UIPanelBase
{
    //--------------------------------
    [Header("[ 높이 ]"), SerializeField]
    TextMeshProUGUI _textHeight;
    public void Set_Height(float height)
    {
        _textHeight.text = height.ToString("#,##0.0");
    }
    //--------------------------------
    [Header("[ 선물 ]"), SerializeField]
    TextMeshProUGUI _textGift;
    public void Set_Gift(int gift)
    {
        _textGift.text = gift.ToString();
    }
    //--------------------------------
    [Header("[ 충돌한 참새 수 ]"), SerializeField]
    TextMeshProUGUI _textBird;
    public void Set_Bird(int bird)
    {
        _textBird.text = bird.ToString();
    }
    //--------------------------------
    [Header("[ 현재 점수 ]"), SerializeField]
    TextMeshProUGUI _textScore;
    public void Set_Score(int score)
    {
        _textScore.text = score.ToString("#,##0");
    }

    [Header("[ 코인 ]"), SerializeField]
    TextMeshProUGUI _textCoin;
    public void Set_Coin(int score)
    {
        _textCoin.text = score.ToString();
    }
    [Header("[ 레벨 ]"), SerializeField]
    TextMeshProUGUI _textLevel;
    public void Set_Level(int level)
    {
        _textLevel.text = level.ToString();
    }
}
