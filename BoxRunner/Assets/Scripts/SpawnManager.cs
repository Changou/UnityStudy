using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("새 프리팹"), SerializeField]
    GameObject _prefab;

    [Header("스폰 위치"), SerializeField]
    Transform _spawnPos;

    [Header("스폰 높이"), SerializeField]
    float _MaxY;

    [Header("스폰 딜레이"), SerializeField]
    float _spawnDelay;

    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return null;
        while (GameManager._Inst._eGameState != GameManager.eGAMESTATE.END) 
        {
            yield return new WaitForSeconds(_spawnDelay);

            GameObject bird = Instantiate(_prefab);
            float ran = Random.Range(0, _MaxY);
            Vector3 pos = new Vector3(_spawnPos.position.x, ran, _spawnPos.position.z);
            bird.transform.position = pos;
        }
    }
}
