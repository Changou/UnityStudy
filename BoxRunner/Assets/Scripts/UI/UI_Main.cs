using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Main : MonoBehaviour
{
    //---------------------------------
    [Header("¿Ãµø ∞≈∏Æ"), SerializeField]
    protected TextMeshProUGUI _runDistText;
    //---------------------------------
    [Header("»πµÊ«— ƒ⁄¿Œ"), SerializeField]
    protected TextMeshProUGUI _coinText;
    //---------------------------------
    public void SetText_RunDist(float runDist)
    {
        _runDistText.text = runDist.ToString("N");
    }
    //---------------------------------
    public void SetText_Coin(int coin)
    {
        _coinText.text = coin.ToString();
    }
}
