using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Speed : Item
{
    public override void ItemFunction()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SpeedUp();
    }
}
