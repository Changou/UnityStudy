using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    [SerializeField] int _raceStartCountdown;
    [SerializeField] Text _raceStartText;
    [SerializeField] CarMove[] _cars;

    private void OnEnable()
    {
        _raceStartText.text = _raceStartCountdown.ToString();
        StartCoroutine(RaceCount());
    }

    private void Update()
    {
        if(GameManager2._Inst._carRanks.Count >= 5)
        {
            UIManager2._Inst.Only_Show_UI(UIManager2.UI.RESULT);
        }
    }

    IEnumerator RaceCount()
    {
        while(_raceStartCountdown > 1)
        {
            yield return new WaitForSeconds(1f);
            --_raceStartCountdown;
            _raceStartText.text = _raceStartCountdown.ToString();
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
