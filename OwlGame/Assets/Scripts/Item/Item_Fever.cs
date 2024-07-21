using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Fever : ItemBase
{
    protected override void Effect()
    {
        if (ItemManager.i._Item_LV[(int)_ItemType] < 5)
            ItemManager.i.FeverUp();

        base.Effect();
    }
}
