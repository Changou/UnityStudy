using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Freeze : Item
{
    public override void Collide(Snake snake)
    {
        base.Collide(snake);
        Spawner.i.ListMonster(_EffectTime);
    }
}
