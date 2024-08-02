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
    //	����..
    int _score = 0;
    //--------------------------------
    //	���� ���� ����..
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        //	�̹� ���� �Ŵ����� �����Ѵٸ�
        //	������ �ı�..
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
