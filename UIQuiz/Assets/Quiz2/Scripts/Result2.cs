using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result2 : MonoBehaviour
{
    [SerializeField] GameObject[] _resultText;

    private void OnEnable()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
