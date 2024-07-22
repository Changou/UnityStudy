using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public enum ITEM_TYPE
{
    COIN,
    FEVER,
    INV,
    JUMP,
    MOVING,
    SHOT,
    SJUMP,

    MAX
}

public class ItemBase : MonoBehaviour
{
    [Header("[ UIÆÐ³Î ]")]
    [SerializeField] UIPanel_Enforce _uiEnforce;

    [Header("[ ¿Ã»©¹Ì ]")]
    [SerializeField] protected GameObject _Owl;

    [SerializeField] TextMeshProUGUI _LVText;

    [SerializeField] ITEM_TYPE _itemType;

    [SerializeField] protected UIPanel_EffectTime _uiEffect;

    public ITEM_TYPE _ItemType => _itemType;

    private void Awake()
    {
        _uiEnforce = GameObject.Find("Panel - Enforce").GetComponent<UIPanel_Enforce>();
        _uiEffect = GameObject.Find("Panel - EffectTime").GetComponent<UIPanel_EffectTime>();
        _Owl = GameObject.Find("Owl");
        Reference();
    }

    private void OnEnable()
    {
        _LVText.text = "LEVEL : " + ItemManager.i._Item_LV[(int)_itemType];
    }

    protected virtual void Reference() { }

    public void ClickICON()
    {
        Effect();
    }

    protected virtual void Effect()
    {
        ItemManager.i.LEVELUP((int)_ItemType);

        _uiEnforce.Destroy();
        GameManager_2._Inst.UnPause();
    }
}