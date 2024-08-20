using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Game _game;
    GAME _cpuSelect;

    [Header("��� UI")]
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

        string result = "����� ";
        
        if((int)_game._mySelect == (int)_cpuSelect)
        {
            result += "�����ϴ�.";
            GameManager._Inst._drawCnt++;
        }
        else if((int)_game._mySelect > (int)_cpuSelect)
        {
            if (_game._mySelect == GAME.�� && _cpuSelect == GAME.����)
            {
                result += "�̰���ϴ�!";
            }
            else
            {
                result += "�����ϴ�..";
            }
        }
        else if((int)_game._mySelect < (int)_cpuSelect)
        {
            if (_game._mySelect == GAME.���� && _cpuSelect == GAME.��)
            {
                result += "�����ϴ�..";
            }
            else
            {
                result += "�̰���ϴ�!";
            }
        }
        _resultText.text = result;

        if(result.Contains("�̰���ϴ�!"))
            GameManager._Inst._winCnt++;
        else if(result.Contains("�����ϴ�.."))
            GameManager._Inst._loseCnt++;

        Debug.Log("cpu : "+_cpuSelect.ToString());
        Debug.Log("�÷��̾� : " + _game._mySelect.ToString());

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
