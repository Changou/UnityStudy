using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CObjList _list;

    [Header("Point")]
    [SerializeField] GameObject[] _point;
    [SerializeField] GameObject _choose;

    [Header("�귿 �ӵ�")]
    [SerializeField] float _Rspeed;

    [Header("UI")]
    [SerializeField] Text _ScoreT;
    [SerializeField] Text _TurnCount;
    [SerializeField] GameObject _TurnBtn;
    [SerializeField] GameObject _StopBtn;
    [SerializeField] GameObject _GameOver;
    [SerializeField] GameObject _ReBtn;

    [Header("����Ƚ��")]
    [SerializeField] int _TurnCnt = 2;

    [Header("��÷")]
    [SerializeField] GameObject _Winning;
    

    bool _isTurn = false;
    bool _isTurnOver = true;
    float point = 0;

    // Start is called before the first frame update
    void Start()
    {
        _ScoreT.text = "���� : " + point;
        _TurnCount.text = "���� Ƚ�� : " + _TurnCnt;
        for(int i = 0; i<_point.Length; i++)
        {
            _list.Append(_point[i]);
        }
        _list.SetCurNodeToNext();
        //ShowCurNode();
    }

    void Score()
    {
        CLList<GameObject>.CircleNode curNode = _list._CurNode;
        point += curNode._data.GetComponent<RulletObj>()._Point;

        _ScoreT.text = "���� : " + point;
        StartCoroutine(WinningDelay((int)curNode._data.GetComponent<RulletObj>()._Point));
    }

    IEnumerator WinningDelay(int winningPoint)
    {
        _Winning.SetActive(true);
        _Winning.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = winningPoint + "���� ��÷�Ǿ����ϴ�.";
        if (winningPoint > 0)
            _Winning.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        _Winning.transform.GetChild(0).gameObject.SetActive(false);
        _Winning.SetActive(false);
        _isTurnOver = true;
        
        if (_TurnCnt == 0)
            GameOver();
        else
            _TurnBtn.SetActive(true);
    }

    public void Restart()
    {
        _ReBtn.SetActive(false);
        _GameOver.SetActive(false);
        point = 0;
        _TurnCnt = 5;
        _ScoreT.text = "���� : " + point;
        _TurnCount.text = "���� Ƚ�� : " + _TurnCnt;
        _TurnBtn.SetActive(true) ;
    }

    void GameOver()
    {
        _GameOver.SetActive(true);
        _GameOver.transform.GetChild(0).GetComponent<Text>().text = "GAME OVER\n���� : " + point;
        _ReBtn.SetActive(true);
    }

    public void OffTurnBtn()
    {
        _isTurn = false;
        StopCoroutine(Turn());
        StartCoroutine(StopPointChoose());
    }

    public void OnTurnBtn()
    {
        if (_isTurnOver && _TurnCnt > 0)
        {
            --_TurnCnt;
            _TurnCount.text = "���� Ƚ�� : " + _TurnCnt;
            _isTurn = true;
            _isTurnOver = false;
            _StopBtn.SetActive(true);
            _TurnBtn.SetActive(false);
            StartCoroutine(Turn());
        }
    }

    IEnumerator StopPointChoose()
    {
        float _stopSpeed = _Rspeed;
        while(_stopSpeed <= 1.5f)
        {
            _list.SetCurNodeToNext();
            ShowCurNode();
            yield return new WaitForSeconds(_stopSpeed);
            _stopSpeed += 0.3f;
        }
        Score();
    }

    IEnumerator Turn()
    {
        while (_isTurn)
        {
            _list.SetCurNodeToNext();
            ShowCurNode();
            yield return new WaitForSeconds(_Rspeed);
        }
    }

    public void ShowCurNode()
    {
        CLList<GameObject>.CircleNode curNode = _list._CurNode;
        if(curNode != null )
        {
            _choose.SetActive(true);
            _choose.transform.parent = curNode._data.transform;
            _choose.transform.localPosition = new Vector3(0, 0, 0.1f);
        }
    }

}
