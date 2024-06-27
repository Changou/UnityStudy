using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    [Header("랭킹")]
    [SerializeField] GameObject _NameIn;
    [SerializeField] GameObject _Rank;
    [SerializeField] Text[] _RankScoreT;
    [SerializeField] Text[] _RankNameT;
    [SerializeField] Text[] _RankText;
    [SerializeField] Text _RankNameCurrent;
    [SerializeField] Text _RankScoreCurrent;
    int[] rankScore = new int[5];
    string[] rankName = new string[5];
    int[] bestScore = new int[5];
    string[] bestName = new string[5];
    string currentName;

    [Header("시간제한(초)"), SerializeField] float time;
    [SerializeField] Text timeT;

    float curTime;
    public bool isGameOver;
    public bool dontShoot;

    [SerializeField] int[] killCount = new int[5];
    [SerializeField] Text[] _ResultT;
    [SerializeField] GameObject _Result;
    [SerializeField] GameObject _ReBtn;

    [SerializeField] InsertSort _InsertSort;


    [Header("점수")]
    [SerializeField] int _Score = 0;
    [SerializeField] Text _ScoreT;

    public Action _event;

    private void Awake()
    {
        i = this;
        isGameOver = true;
        dontShoot = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void ScoreSet()
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", _Score);

        int tmpScore = 0;
        string tmpName = "";

        for(int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            while (bestScore[i] < _Score)
            {
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = _Score;
                bestName[i] = currentName;

                PlayerPrefs.SetInt(i + "BestScore", _Score);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                currentName = tmpName;
                _Score = tmpScore;
            }
        }
        for(int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }
        Ranking();
    }

    void Ranking()
    {
        _RankNameCurrent.text = PlayerPrefs.GetString("CurrentPlayerName");
        _RankScoreCurrent.text = PlayerPrefs.GetInt("CurrentPlayerScore").ToString();

        for(int i = 0; i < 5; i++)
        {
            _RankScoreT[i].text = PlayerPrefs.GetInt(i + "BestScore").ToString();
            rankName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");
            _RankNameT[i].text = string.Format(rankName[i]);

            if (_RankScoreCurrent.text.Equals(_RankScoreT[i].text) && _RankNameCurrent.text.Equals(_RankNameT[i].text))
            {
                Color rank = new Color(255,255,0);
                _RankText[i].color = rank;
                _RankNameT[i].color = rank;
                _RankScoreT[i].color = rank;
            }
        }
    }

    public void StartGame()
    {
        _NameIn.SetActive(false);
        currentName = _NameIn.transform.GetChild(1).GetComponent<InputField>().text;
        _event();
        dontShoot = true;
        timeT.text = string.Format("{00:N2}", time);
        _ScoreT.text = "점수 : " + _Score;
        StartCoroutine(StartTimer());
    }

    public void ScoreUp(int score)
    {
        _Score += score;
        _ScoreT.text = "점수 : " + _Score.ToString();
    }

    public void KillCount(int type)
    {
        killCount[type]++;
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(0.5f);
        curTime = time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;

            timeT.text = string.Format("{00:N2}", curTime);
            yield return null;
            if (curTime <= 0)
            {
                curTime = 0;
                isGameOver = false;
                GameClear();
                yield break;
            }
        }
    }

    void GameClear()
    {
        _InsertSort.Sort(ref killCount);
        _Result.SetActive(true);
        _Rank.SetActive(true);
        _ReBtn.SetActive(true);
        dontShoot = false;
        for(int i = 0; i < 5; i++)
        {
            _ResultT[i].text = $"{_InsertSort._Monster[i].GetComponent<Monster>()._MonType} : {killCount[i]}";
        }
        ScoreSet();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
