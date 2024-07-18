using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBase : MonoBehaviour
{
    [Header("[ 스폰 포인트 ]"), SerializeField]
    protected Transform _spawnPt;

    protected Vector3 _worldSize;

    private void Awake()
    {
        InitData();
    }

    private void Update()
    {
        Make();
    }

    void InitData()
    {
        Vector3 scrSize = new Vector3(Screen.width, Screen.height);

        //  월드 좌표를 계산하려는
        //  카메라로 부터의 깊이 값..
        //  -   거리와 다른 개념..
        scrSize.z = 10;
        _worldSize = Camera.main.ScreenToWorldPoint(scrSize);
    }

    protected virtual void Make() { }
}
