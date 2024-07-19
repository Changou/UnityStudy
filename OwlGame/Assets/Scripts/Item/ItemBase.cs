using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [Header("[ ������ ]")]
    [SerializeField] protected int _lv = 1;

    [Header("UI�г�")]
    [SerializeField] UIPanel_Enforce _uiEnforce;

    [SerializeField] TextMeshPro _LVText;

    public int _LV => _lv;

    private void OnEnable()
    {
        _LVText.text = "LEVEL : " + _lv;
    }

    public void ClickICON()
    {
        Effect();
    }

    protected virtual void Effect()
    {  
        ++_lv;
        _uiEnforce.Destroy();
    }
}