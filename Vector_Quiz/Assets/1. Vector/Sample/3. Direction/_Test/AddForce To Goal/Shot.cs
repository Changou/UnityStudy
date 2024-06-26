//===============================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//===============================================================
public class Shot : MonoBehaviour
{
    //---------------------------------------
    [Header("총알 프리팹"), SerializeField]
    GameObject _bulletPref;

    [Header("속도"), SerializeField]
    float _bulletSpeed = 5;
    //---------------------------------------
    [Header("타겟 트랜스폼"), SerializeField]
    Transform _targetTransf;
    //---------------------------------------
    void Update()
    {
        if( Input.GetMouseButtonUp(0) )
        {
            Vector3 dir = _targetTransf.position - transform.position;
            
            GameObject bullet = Instantiate(_bulletPref);

            bullet.transform.position = transform.position + Vector3.up;

            bullet.GetComponent<Rigidbody>().AddForce(dir.normalized * _bulletSpeed);

        }// if( Input.GetMouseButtonUp(0) )

    }// void Update()
    //---------------------------------------

}// public class Shot : MonoBehaviour
 //===============================================================