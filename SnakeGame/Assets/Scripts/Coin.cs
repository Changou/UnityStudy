using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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
        Debug.Log(Spawner.i._posX);
        float x = Random.Range(-Spawner.i._posX, Spawner.i._posX);
        float z = Random.Range(-Spawner.i._posZ, Spawner.i._posZ);

        transform.position = new Vector3(x, 0, z);
    }
    public void Collide(Snake snake)
    {
        Move_Random();
        snake.AddTail();
    }
}
