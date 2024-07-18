using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_3 : Owl_2
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        ICollision iColl = collision.gameObject.GetComponent<ICollision>();

        //  [ ?. ]
        //  -   �� ���� ������..
        //  -   [ iColl ] ���� null�̶��..
        //      -   Y.. :   ���� ó��..
        //          N.. :   null ��ȯ..
        //                  -   �ƹ��ϵ� ���� ����..
        iColl?.OnCollide(collision.transform.position);
    }
}
