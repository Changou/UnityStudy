using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result2 : MonoBehaviour
{
    [SerializeField] GameObject[] _resultText;
    [SerializeField] Text _selectRank;

    private void Awake()
    {
        GameManager2._Inst._GameResetEvent += () =>
        {
            for (int i = 0; i < _resultText.Length; i++)
            {
                _resultText[i].SetActive(false);
            }
        };
    }

    private void OnEnable()
    {
        _selectRank.text = GameManager2._Inst.MyRank() + "µî";

        CinemachineBrain.SoloCamera = null;
        if (GameManager2._Inst._carRanks[0] == GameManager2._Inst._selectCar)
        {
            _resultText[0].SetActive(true);
        }
        else
        {
            _resultText[1].SetActive(true);
        }
    }

    public void RestartBtn()
    {

        GameManager2._Inst.GameReset();
    }
}
