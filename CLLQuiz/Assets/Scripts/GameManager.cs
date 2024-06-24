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

    [Header("·ê·¿ ¼Óµµ")]
    [SerializeField] float _Rspeed;

    [Header("UI")]
    [SerializeField] Text _ScoreT;
    [SerializeField] Text _TurnCount;
    [SerializeField] GameObject _TurnBtn;
    [SerializeField] GameObject _StopBtn;

    bool _isTurn = false;
    bool _isTurnOver = true;
    float point = 0;
    int _TurnCnt = 5;

    // Start is called before the first frame update
    void Start()
    {
        _ScoreT.text = "Á¡¼ö : " + point;
        _TurnCount.text = "³²Àº È½¼ö : " + _TurnCnt;
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
        _ScoreT.text = "Á¡¼ö : " + point;
        --_TurnCnt;
        _TurnCount.text = "³²Àº È½¼ö : " + _TurnCnt;
        _isTurnOver = true;
        _TurnBtn.SetActive(true);
    }

    public void OffTurnBtn()
    {
        _isTurn = false;
        StopCoroutine(Turn());
        StartCoroutine(StopPointChoose());
    }

    public void OnTurnBtn()
    {
        if (_isTurnOver)
        {
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
        while(_stopSpeed <= 2f)
        {
            _list.SetCurNodeToNext();
            ShowCurNode();
            yield return new WaitForSeconds(_stopSpeed);
            _stopSpeed += 0.2f;
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
