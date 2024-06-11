using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillPatrol : MonoBehaviour
{
    int[] killCnt = {0,0,0,0 };

    [SerializeField] Text[] _t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Patrol"))
                {
                    string patrolName = hit.collider.name;
                    int patrolNumber = int.Parse(patrolName.Substring(patrolName.Length - 1))-1;
                    
                    killCnt[patrolNumber]++;

                    if (killCnt[patrolNumber] >= 3)
                    {
                        Debug.Log(hit.collider.name + "이 사망하였습니다.");
                        Destroy(hit.collider.gameObject);
                        _t[patrolNumber].text = hit.collider.name + " : DIE"; 
                    }
                }
            }
        }
    }
}
