using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICollide
{
    void Collide(Snake snake);
}

public class Coin : MonoBehaviour , ICollide
{
    // Start is called before the first frame update
    void Start()
    {
        Move_Random();
    }

    void Move_Random()
    {
        float x = Random.Range(-9f, 9f);
        float z = Random.Range(-4f, 4f);

        transform.position = new Vector3(x, 0, z);
    }
    public void Collide(Snake snake)
    {
        Move_Random();
        snake.AddTail();
    }
}
