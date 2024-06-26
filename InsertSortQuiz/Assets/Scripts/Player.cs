using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("ÃÑ¾Ë")]
    [SerializeField] GameObject bulletPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.i.isGameOver)
        {
            LookMouseCursor();
        }
    }


    void LookMouseCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.forward = mouseDir;
            if(Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.forward + new Vector3(0,0.7f,0);
                bullet.transform.forward = mouseDir;
            }
        }
    } 
}
