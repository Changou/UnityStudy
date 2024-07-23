using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Item_Fever : ItemBase
{
    [Header("[ ÇÇ¹ö ]"), SerializeField] FeverSpawnManager _fever;
    protected override void Effect()
    {
        if (ItemManager.i._Item_LV[(int)_ItemType] < 5)
            ItemManager.i.FeverUp();

        _uiEffect.SetEffectTime(transform.GetChild(0).GetComponent<Image>().sprite, ItemManager.i._FeverEffect);
        _fever.Fever(ItemManager.i._FeverEffect);
        base.Effect();
    }

    protected override void Reference()
    {
        _fever = GameObject.Find("FeverManager").GetComponent<FeverSpawnManager>();
    }
}
