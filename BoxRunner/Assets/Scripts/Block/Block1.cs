using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block1 : MonoBehaviour
{
    [Header("장애물 전기")]
    [SerializeField] GameObject _line;
    [SerializeField] Transform _startPos;
    [SerializeField] Transform _endPos;

    [SerializeField] float _electricDelay = 4f;
    float _time;

    [SerializeField] TextMeshPro[] _timeT;
    bool isWork = false;

    private void Awake()
    {
        _line.SetActive(false);
    }

    private void Update()
    {
        if (_time > 0 && !isWork)
        {
            _time -= 1f * Time.deltaTime;
            foreach(TextMeshPro text in _timeT)
            {
                text.text = _time.ToString("N0");
            }
        }
        else 
        {
            if(!isWork) 
            { 
                isWork = true; 
                _time = 0.5f; 
                _line.SetActive(true);
            }
            
            _time -= 1 * Time.deltaTime;

            foreach (TextMeshPro text in _timeT)
            {
                text.text = "JUMP!";
            }

            if(_time <= 0) { Reset(); }
        }
    }

    private void Reset()
    {
        _line.SetActive(false);
        _time = _electricDelay;
        isWork = false;
    }
}
