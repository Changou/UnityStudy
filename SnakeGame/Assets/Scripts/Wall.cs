using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, ICollide
{
    public void Collide(Snake snake) { snake.Dead(); }
}
