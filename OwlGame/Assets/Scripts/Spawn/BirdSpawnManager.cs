using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnManager : SpawnBase
{
    [Header("[ 참새 프리팹 ]"), SerializeField]
    Bird _prefabBird;

    protected override void Make()
    {
        //  현재 생성된 참새의
        //  갯수 구하기..
        int cnt = GameObject.FindGameObjectsWithTag("Bird").Length;

        //  화면에 생성된 참새가
        //  7개를 초과하면
        //  생성 취소..
        if (cnt > 7)
            return;

        //  확률이 90% 미만인 경우
        //  취소..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  생성 위치 설정..
        Vector3 pos = _spawnPt.position;
        pos.y -= Random.Range(0, 5f);

        GameObject bird = Instantiate(_prefabBird.gameObject);
        bird.transform.position = pos;
    }
}
