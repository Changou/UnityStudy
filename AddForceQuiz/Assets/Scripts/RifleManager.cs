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

    [Header("ÃÑ±â¹Ýµ¿")]
    [SerializeField] Vector3 reboundVector;
    [SerializeField] Vector3 recoilSmoothDampVelocity = Vector3.zero;
    [SerializeField] float recoilTime;

    Vector3 currentV;
    bool isShoot = true;
    int shootCnt = 0;
    bool isDelay = true;
    // Start is called before the first frame update
    void Start()
    {
        currentV = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isShoot && shootCnt < 5)
        {
            if (isDelay)
            {
                Shot();
                Rebound();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isShoot = true;
            shootCnt = 0;
        }
        if (recoilSmoothDampVelocity != Vector3.zero)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, currentV, ref recoilSmoothDampVelocity, 0.1f);
        }
        else
            transform.localPosition = currentV;
    }

    void Rebound()
    {
        reboundVector = transform.localPosition - new Vector3 (0f, 0f, 0.1f);
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, reboundVector, ref recoilSmoothDampVelocity, recoilTime);
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
