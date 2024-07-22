using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawnManager : SpawnBase
{
    [Header("[ ���� ������ ]"), SerializeField]
    Coin _prefabCoin;

    [Header("UI ����Ʈ Ÿ��")]
    [SerializeField] UIPanel_EffectTime _uieffect;

    float delay = 0.1f;

    public void Fever(float time)
    {
        while ()
        {
            if (delay < 0)
            {
                Vector3 pos = _spawnPt.position;
                pos.x = Random.Range(-_worldSize.x, _worldSize.x);

                GameObject coin = Instantiate(_prefabCoin.gameObject);
                coin.transform.position = pos;
                coin.GetComponent<Rigidbody2D>().gravityScale = 1f;
                delay = 0.1f;
            }
            else
                delay -= Time.deltaTime;
        }    
    }
    

    
}
