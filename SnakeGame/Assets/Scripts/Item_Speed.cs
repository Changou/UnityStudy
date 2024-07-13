using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Speed : Item
{
    public override void Collide(Snake snake)
    {
        base.Collide(snake);
        snake.OnSpeed(_EffectTime);
    }
}
