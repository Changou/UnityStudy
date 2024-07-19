using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Moving : ItemBase
{
    protected override void Effect()
    {
        ItemManager.i.MovingUp();

        base.Effect();
    }
}
