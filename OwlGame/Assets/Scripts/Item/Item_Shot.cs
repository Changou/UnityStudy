using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Item_Shot : ItemBase
{

    protected override void Effect()
    {
        ItemManager.i.ShotUp();
        _Owl.GetComponent<GunManager>().GunActive(ItemManager.i._ShotEffect);

        base.Effect();
    }
}
