using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawnManager : SpawnBase
{
    [Header("[ 코인 프리팹 ]"), SerializeField]
    Coin _prefabCoin;

    public void Fever(float time)
    {
        
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x, _worldSize.x);

        GameObject coin = Instantiate(_prefabCoin.gameObject);
        coin.transform.position = pos;
        coin.GetComponent<Rigidbody2D>().gravityScale = 1f;
        if(time >= 0)
            StartCoroutine(Delay(time));
    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(0.1f);
        time -= 0.1f;
        Fever(time);
    }
}
