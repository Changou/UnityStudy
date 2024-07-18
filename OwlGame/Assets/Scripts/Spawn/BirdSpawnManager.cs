using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnManager : SpawnBase
{
    [Header("[ ���� ������ ]"), SerializeField]
    Bird _prefabBird;

    protected override void Make()
    {
        //  ���� ������ ������
        //  ���� ���ϱ�..
        int cnt = GameObject.FindGameObjectsWithTag("Bird").Length;

        //  ȭ�鿡 ������ ������
        //  7���� �ʰ��ϸ�
        //  ���� ���..
        if (cnt > 7)
            return;

        //  Ȯ���� 90% �̸��� ���
        //  ���..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  ���� ��ġ ����..
        Vector3 pos = _spawnPt.position;
        pos.y -= Random.Range(0, 5f);

        GameObject bird = Instantiate(_prefabBird.gameObject);
        bird.transform.position = pos;
    }
}
