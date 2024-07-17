using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_3 : Owl_2
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        ICollision iColl = collision.gameObject.GetComponent<ICollision>();

        //  [ ?. ]
        //  -   널 조건 연산자..
        //  -   [ iColl ] 값이 null이라면..
        //      -   Y.. :   정상 처리..
        //          N.. :   null 반환..
        //                  -   아무일도 하지 않음..
        iColl?.OnCollide(collision.transform.position);
    }
}
