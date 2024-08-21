using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    [SerializeField] Text[] _ranks;

    private void OnEnable()
    {
        for (int i = 0; i < _ranks.Length; i++)
        {
            _ranks[i].text = $"{i + 1}µî. {GameManager2._Inst._carRanks[i]} CAR";
        }
    }
}
