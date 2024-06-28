using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : Character
{
    [SerializeField] GameObject bulletPf;
    public override void Motion()
    {
        transform.GetComponent<Animator>().SetTrigger("IsShoot");
        GameObject bullet = Instantiate(bulletPf);
        bullet.transform.parent = transform;
        bullet.transform.localPosition = new Vector3(0, 0.5f, 1);
        bullet.GetComponent<Renderer>().material.color = Color.yellow;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 800f);
        Destroy(bullet, 2f);
    }
}
