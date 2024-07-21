using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SJump : ItemBase
{
    protected override void Effect()
    {
        if (ItemManager.i._Item_LV[(int)_ItemType] < 5)
            ItemManager.i.SjumpUp();
        _Owl.GetComponent<Owl_6>().SJump(ItemManager.i._SjumpEffect) ;

        base.Effect();
    }
}
