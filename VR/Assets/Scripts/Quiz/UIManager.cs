using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
public enum UI
{
    BOX,
    TIMER,
    START,
    WIN,
    LOSE
}

public class UIManager : MonoBehaviour
{
    [SerializeField] BoxCheck _boxCheck;
    [SerializeField] Text _boxText;
    [SerializeField] Text _time;

    [SerializeField] UIBase[] _uis;
   

    private void Awake()
    {
        _uis = GetComponentsInChildren<UIBase>();
    }

    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        _boxText.text = "BOX : " + _boxCheck.BoxCount;
    }

    public int BoxCount
    {
        get { return _boxCheck.BoxCount; }
    }

    public void AllActive(bool isOn)
    {
        foreach (UIBase ui in _uis)
        {
            ui.Show(isOn);
        }
    }

    public void Show_Only_Ui(UI ui, bool isOn)
    {
        _uis[(int)ui].Show(isOn);
    }

    public void GameStartUI()
    {
        AllActive(false);
        Show_Only_Ui(UI.BOX, true);
        Show_Only_Ui(UI.TIMER, true);
    }
}
