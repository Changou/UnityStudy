using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] BoxCheck _boxCheck;
    [SerializeField] Text _boxText;

    private void Update()
    {

        UpdateUI();
    }

    void UpdateUI()
    {
        _boxText.text = "BOX : " + _boxCheck.BoxCount;
    }
}
