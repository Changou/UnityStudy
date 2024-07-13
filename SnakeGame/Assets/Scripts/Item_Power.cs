using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Power : Item
{
    public override void Collide(Snake snake)
    {
        base.Collide(snake);
        snake.OnPower(_EffectTime);
    }
}
