using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawnManager : SpawnBase
{
    [Header("[ �������� ������ ]"), SerializeField]
    Branch _prefabBranch;

    protected override void Make()
    {
        //  ���� ������ ����������
        //  ���� ���ϱ�..
        int cnt = GameObject.FindGameObjectsWithTag("Branch").Length;

        //  ȭ�鿡 �ִ� ����������
        //  ������ 3���� �ʰ��ϸ�
        //  ���� ���..
        if (cnt > 3)
            return;

        //  ���� ���� ���̿�
        //  ������׷� ��ġ..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);

        //  �������� ����..
        GameObject branch = Instantiate(_prefabBranch.gameObject);
        branch.transform.position = pos;

        //  ���� ���� ��ġ ����..
        _spawnPt.position += new Vector3(0, 3, 0);

    }
}
