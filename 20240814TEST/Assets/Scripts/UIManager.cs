using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _boxText;
    [SerializeField] BoxCheck _box;

    [SerializeField] Text _timerText;
    [Header("초"),SerializeField] int _timer;

    [SerializeField] public GameObject[] _gameOverUis;

    float _curTime;
    int _min;
    int _sec;

    private void Start()
    {
        _boxText.text = "Box : " + _box._Count;
        _timerText.text = _timer / 60 + " : " + (_timer % 60).ToString("00");
        _curTime = _timer;
    }

    private void Update()
    {
        if (GameManager._Inst._isGameOver) return;

        Timer();
        UpdateUI();

    }

    void Timer()
    {
        if (_curTime <= 0)
        {
            if(_box._Count >= 3)
            {
                GameManager._Inst.GameOver(true);
            }
            else
                GameManager._Inst.GameOver(false);
        }
        _curTime -= 1 * Time.deltaTime;
        _min = (int)(_curTime / 60);
        _sec = (int)(_curTime % 60);
    }

    void UpdateUI()
    {
        _boxText.text = "Box : " + _box._Count;
        _timerText.text = _min.ToString() + " : " + _sec.ToString("00");
        if(_box._Count >= 5)
        {
            GameManager._Inst.GameOver(true);
        }
    }
}
