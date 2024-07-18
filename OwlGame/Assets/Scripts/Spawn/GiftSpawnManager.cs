using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawnManager : SpawnBase
{
    [Header("[ 선물 프리팹 ]"), SerializeField]
    Gift _prefabGift;

    protected override void Make()
    {
        //  생성된 선물 상자 갯수 구하기..
        int cnt = GameObject.FindGameObjectsWithTag("Gift").Length;

        //  선물이 화면에 3개 이상이면
        //  취소..
        if (cnt >= 3)
            return;

        //  확률이 90% 미만인 경우
        //  취소..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  위치 설정..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);
        pos.y += Random.Range(0.5f, 1.5f);

        //  이름 설정..
        GameObject gift = Instantiate(_prefabGift.gameObject);
        gift.name = "Gift " + Random.Range(0, 3);
        gift.transform.position = pos;
    }
}
