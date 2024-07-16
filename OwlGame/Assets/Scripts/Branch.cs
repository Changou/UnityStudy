using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{ 
    void Awake()
    {
        InitData();
    }
    //---------------------------
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        if (pos.y < -30f)
            Destroy(gameObject);

    }// void Update()
    //---------------------------
    void InitData()
    {
        //  �������� �ʺ�..
        float scaleWidth = Random.Range(0.5f, 1f);

        //  �������� ����..
        int dirX = (Random.Range(0, 2) == 0) ? -1 : 1;
        int dirY = (Random.Range(0, 2) == 0) ? -1 : 1;

        transform.localScale = new Vector3(scaleWidth * dirX, dirY, 1);

    }
}
