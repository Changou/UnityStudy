using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] Transform bulletSpawnPosition;

    [Header("ÃÑ¾Ë°ü·Ã")]
    [SerializeField] float bulletSpeed;
    [SerializeField, Range(0, 15)] int bulletAccuracy;

    bool isShoot = true;
    int shootCnt = 0;
    bool isDelay = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isShoot && shootCnt < 5)
        {
            if(isDelay)
                Shot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isShoot = true;
            shootCnt = 0;
        }
    }

    void Shot()
    {
        GameObject bullet = Instantiate(prefab);
        bullet.transform.position = bulletSpawnPosition.position;
        bullet.transform.GetChild(0).GetChild(1).localRotation = 
            Quaternion.Euler(0, Random.Range(-bulletAccuracy, bulletAccuracy), Random.Range(-bulletAccuracy, bulletAccuracy));
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        shootCnt++;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        isDelay = false;
        yield return new WaitForSeconds(0.1f);
        isDelay = true;
    }
}
