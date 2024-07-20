using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [Header("[ ������ ]")]
    [SerializeField] protected int _lv = 1;

    [Header("[ UI�г� ]")]
    [SerializeField] UIPanel_Enforce _uiEnforce;

    [Header("[ �û��� ]")]
    [SerializeField] protected GameObject _Owl;

    [SerializeField] TextMeshPro _LVText;

    public int _LV => _lv;

    private void Awake()
    {
        _uiEnforce = GameObject.Find("Panel - Enforce").GetComponent<UIPanel_Enforce>();
        _Owl = GameObject.Find("Owl");
    }

    public void ClickICON()
    {
        Effect();
    }

    protected virtual void Effect()
    {  
        ++_lv;
        _uiEnforce.Destroy();
        GameManager_2._Inst.UnPause();
    }
}