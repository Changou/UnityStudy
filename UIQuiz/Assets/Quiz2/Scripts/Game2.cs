using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    [SerializeField] int _raceStartCountdown;
    [SerializeField] int _countDown;
    [SerializeField] Text _raceStartText;
    [SerializeField] CarMove[] _cars;

    private void Awake()
    {
        GameManager2._Inst._GameResetEvent += () =>
        {
            foreach (CarMove car in _cars)
            {
                car.transform.position = new Vector3(car.transform.position.x, 0.45f, -70f);
                car.enabled = false;
            }
        };
    }

    private void OnEnable()
    {
        _countDown = _raceStartCountdown;
        _raceStartText.text = _raceStartCountdown.ToString();
        StartCoroutine(RaceCount());
    }

    private void Update()
    {
        if(GameManager2._Inst._carRanks.Count >= 5)
        {
            Time.timeScale = 1.0f;
            UIManager2._Inst.Only_Show_UI(UIManager2.UI.RESULT);
        }
    }

    IEnumerator RaceCount()
    {
        while(_countDown > 1)
        {
            yield return new WaitForSeconds(1f);
            --_countDown;
            _raceStartText.text = _countDown.ToString();
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        _raceStartText.text = "레이스";
        yield return new WaitForSeconds(1f);
        _raceStartText.text = "스타트!";
        RaceStart();
    }

    void RaceStart()
    {
        foreach (CarMove car in _cars)
        {
            car.enabled = true;
        }
    }
}
