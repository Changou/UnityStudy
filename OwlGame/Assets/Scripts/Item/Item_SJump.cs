using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SJump : ItemBase
{
    protected override void Effect()
    {
        ItemManager.i.CoinUp();

        base.Effect();
    }
}
