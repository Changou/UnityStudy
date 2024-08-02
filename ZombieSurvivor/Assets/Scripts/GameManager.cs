using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }
    //	점수..
    int _score = 0;
    //--------------------------------
    //	게임 오버 상태..
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        //	이미 게임 매니져가 존재한다면
        //	본인을 파괴..
        if (Instance != null && Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        FindObjectOfType<PlayerHealth>().OnDeath += EndGame;
    }

    public void EndGame()
    {
        IsGameOver = true;
        UIManager.Instance.SetActiveGameoverUI(true);
    }

    public void AddScore(int score)
    {
        if (!IsGameOver)
        {
            _score += score;
            UIManager.Instance.UpdateScoreText(_score);
        }
    }
}
