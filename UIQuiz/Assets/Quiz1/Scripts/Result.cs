using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Game _game;
    GAME _cpuSelect;

    [Header("결과 UI")]
    [SerializeField] Image _cpuImg;
    [SerializeField] Image _playerImg;
    [SerializeField] Text _resultText;
    [SerializeField] float _delay;

    private void OnEnable()
    {
        _resultText.text = "";
        int ran = Random.Range(0, (int)GAME.MAX);
        if (GameManager._Inst._IsTestOn) ran = 1;
        _cpuSelect = (GAME)ran;

        _cpuImg.sprite = _game._sprites[(int)_cpuSelect];
        _playerImg.sprite = _game._sprites[(int)_game._mySelect];

        string result = "당신은 ";
        
        if((int)_game._mySelect == (int)_cpuSelect)
        {
            result += "비겼습니다.";
            GameManager._Inst._drawCnt++;
        }
        else if((int)_game._mySelect > (int)_cpuSelect)
        {
            if (_game._mySelect == GAME.보 && _cpuSelect == GAME.바위)
            {
                result += "이겼습니다!";
            }
            else
            {
                result += "졌습니다..";
            }
        }
        else if((int)_game._mySelect < (int)_cpuSelect)
        {
            if (_game._mySelect == GAME.바위 && _cpuSelect == GAME.보)
            {
                result += "졌습니다..";
            }
            else
            {
                result += "이겼습니다!";
            }
        }
        _resultText.text = result;

        if(result.Contains("이겼습니다!"))
            GameManager._Inst._winCnt++;
        else if(result.Contains("졌습니다.."))
            GameManager._Inst._loseCnt++;

        Debug.Log("cpu : "+_cpuSelect.ToString());
        Debug.Log("플레이어 : " + _game._mySelect.ToString());

        StartCoroutine(Delay());
    }

    public void SkipBtn()
    {
        StopAllCoroutines();
        ResultDiscrimination();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
        ResultDiscrimination();
    }

    void ResultDiscrimination()
    {
        if (++GameManager._Inst._gameCnt >= GameManager._Inst._maxGameCnt)
        {
            UIManager._Inst.OffText();
            UIManager._Inst.Only_Show_UI(UIManager.UI.END);
        }
        else
        {
            UIManager._Inst.Only_Show_UI(UIManager.UI.GAME);
        }
    }
}
