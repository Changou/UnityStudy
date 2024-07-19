using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Item_Shot : ItemBase
{
    [SerializeField] GunManager _gunManager;

    protected override void Effect()
    {
        ItemManager.i.ShotUp();
        _gunManager.GunActive(ItemManager.i._ShotEffect);

        base.Effect();
    }
}
