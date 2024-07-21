using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_InV : ItemBase
{
    protected override void Effect()
    {
        if (ItemManager.i._Item_LV[(int)_ItemType] < 5)
            ItemManager.i.InvUp();
        _Owl.GetComponent<Owl_6>().Invincibility(ItemManager.i._InvEffect);

        base.Effect();
    }
}
