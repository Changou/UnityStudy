using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Coin : ItemBase
{
    protected override void Effect()
    {
        if (ItemManager.i._Item_LV[(int)_ItemType] < 5)
            ItemManager.i.CoinUp();

        base.Effect();
    }
}
