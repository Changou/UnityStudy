using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : UIBase
{

    [Header("타이머(분)"), SerializeField] float _time = 3f;

    Text _timeText;
    int _sec;
    int _min;
    private void Awake()
    {
        _timeText = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _timeText.text = _time.ToString() + " : 00";

        _time *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._IsGameOver || !GameManager.Instance._IsGameStart) return;

        _time -= 1f * Time.deltaTime;
        _min = (int)(_time / 60f);
        _sec = (int)(_time % 60f);
        _timeText.text = _min + " : " + _sec.ToString("00");
        if(_time <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
    
}
