using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] Transform bulletSpawnPosition;

    [Header("ÃÑ¾Ë°ü·Ã")]
    [SerializeField] float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        GameObject bullet = Instantiate(prefab);
        bullet.transform.position = bulletSpawnPosition.position;
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
    }
}
