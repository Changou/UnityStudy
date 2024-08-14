using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _Inst;

    [SerializeField] UIManager _uiManger;
    
    public bool _isGameOver = false;

    private void Awake()
    {
        _Inst = this;
    }

    private void Start()
    {
        _isGameOver = false;
    }

    public void GameOver(bool isClear)
    {
        _isGameOver = true;
        if (isClear)
        {
            _uiManger._gameOverUis[1].SetActive(true);
        }
        else
        {
            _uiManger._gameOverUis[0].SetActive(true);
        }
    }
}
