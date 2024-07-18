using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    protected AudioSource _audioSource;
    protected Collider2D _collider2D;
    //---------------------------
    protected int _idx = 0;
    //---------------------------
    [Header("[ 선물 이미지 ]"), SerializeField]
    Sprite[] _giftImages;
    //---------------------------
    void Start()
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
        string name = transform.name;

        /*
            String.Substring..

            -   String.Substring( [ 시작위치 ], [ 문자열길이 ] )
        */
        _idx = int.Parse(name.Substring(5, 1));

        GetComponent<SpriteRenderer>().sprite = _giftImages[_idx];

        _audioSource = GetComponent<AudioSource>();
        _collider2D = GetComponent<Collider2D>();

    }
}
