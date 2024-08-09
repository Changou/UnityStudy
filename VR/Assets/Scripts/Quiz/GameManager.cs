using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] UIManager _uiManager;

    [SerializeField] GameObject _blind;

    private void Awake()
    {
        Instance = this;
    }

    public bool _IsGameStart;
    public bool _IsGameOver;

    private void Start()
    {
        _blind.SetActive(true);
        _uiManager.AllActive(false);
        _uiManager.Show_Only_Ui(UI.START, true);
        _IsGameStart = false;
        _IsGameOver = false;
    }

    public void GameStart()
    {
        _blind.SetActive(false);
        _uiManager.GameStartUI();
        _IsGameStart = true;
    }

    public void GameOver()
    {
        _IsGameOver = true;
        _uiManager.AllActive(false);
        if (_uiManager.BoxCount >= 3)
        {
            _uiManager.Show_Only_Ui(UI.WIN, true);
        }
        else
        {
            _uiManager.Show_Only_Ui(UI.LOSE, true);
        }
    }

}
