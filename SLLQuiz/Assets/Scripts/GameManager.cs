using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SSL.i.Remove(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SSL.i.Remove(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SSL.i.Remove(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SSL.i.Remove(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SSL.i.Remove(4);
        }
    }
}
