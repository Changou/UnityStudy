using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnManager : SpawnBase
{
    [Header("[ ���� ������ ]"), SerializeField]
    Coin _prefabCoin;

    protected override void Make()
    {
        //  ������ ���� ���� ���� ���ϱ�..
        int cnt = GameObject.FindGameObjectsWithTag("Gift").Length;

        //  ������ ȭ�鿡 3�� �̻��̸�
        //  ���..
        if (cnt >= 3)
            return;

        //  Ȯ���� 90% �̸��� ���
        //  ���..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  ��ġ ����..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);
        pos.y += Random.Range(0.5f, 1.5f);

        //  �̸� ����..
        GameObject gift = Instantiate(_prefabCoin.gameObject);
        gift.transform.position = pos;
    }
}
