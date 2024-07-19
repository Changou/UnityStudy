using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Coin : ItemBase
{
    protected override void Effect()
    {
        ItemManager.i.CoinUp();

        base.Effect();
    }
}
