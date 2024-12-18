using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Item_Shot : ItemBase
{

    protected override void Effect()
    {
        if (ItemManager.i._Item_LV[(int)_ItemType] < 5)
            ItemManager.i.ShotUp();
        if (ItemManager.i._Item_LV[(int)_ItemType] == 5)
            _Owl.GetComponent<GunManager>().GunActive(5);
        else
            _Owl.GetComponent<GunManager>().GunActive(ItemManager.i._ShotEffect);

        base.Effect();
    }
}
