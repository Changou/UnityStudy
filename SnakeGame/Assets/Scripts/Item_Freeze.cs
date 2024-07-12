using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Freeze : Item
{
    public override void Collide(Snake snake)
    {
        Spawner.i.ListMonster();
    }
}
