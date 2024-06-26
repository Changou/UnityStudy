using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Reverser : Item
{
    public override void ItemFunction()
    {
        Monster monster = GameObject.Find("Monster(Clone)").GetComponent<Monster>();
        monster.StartReversal();
    }
}
