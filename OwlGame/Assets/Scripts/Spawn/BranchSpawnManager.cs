using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawnManager : SpawnBase
{
    [Header("[ 나뭇가지 프리팹 ]"), SerializeField]
    Branch _prefabBranch;

    protected override void Make()
    {
        //  현재 생성된 나뭇가지의
        //  갯수 구하기..
        int cnt = GameObject.FindGameObjectsWithTag("Branch").Length;

        //  화면에 있는 나뭇가지의
        //  갯수가 3개를 초과하면
        //  생성 취소..
        if (cnt > 3)
            return;

        //  스폰 지점 높이에
        //  지그재그로 배치..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);

        //  나뭇가지 생성..
        GameObject branch = Instantiate(_prefabBranch.gameObject);
        branch.transform.position = pos;

        //  스폰 지점 위치 갱신..
        _spawnPt.position += new Vector3(0, 3, 0);

    }
}
