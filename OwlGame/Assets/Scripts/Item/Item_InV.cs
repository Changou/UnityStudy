using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_InV : ItemBase
{
    protected override void Effect()
    {
        if (ItemManager.i._Item_LV[(int)_ItemType] < 5)
            ItemManager.i.InvUp();

        _uiEffect.SetEffectTime(transform.GetChild(0).GetComponent<Image>().sprite, ItemManager.i._InvEffect);
        _Owl.GetComponent<Owl_6>().Invincibility(ItemManager.i._InvEffect);

        base.Effect();
    }
}
