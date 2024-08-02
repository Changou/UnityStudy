using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] _items;         //	생성할 아이템 프리팹..
    public Transform _playerTransform;  //	플레이어 트랜스폼..
    //-----------------------------------	
    public float _maxDist = 5f;         //	플레이어 위치에서 
                                        //	아이템이 배치될 최대 반경..
    //-----------------------------------
    public float _spawnTimeMax = 7f;    //	최대 시간 간격..
    public float _spawnTimeMin = 2f;    //	최소 시간 간격..
    float _spawnTime;                   //	생성 간격..
    float _lastSpawnTime;               //	마지막 아이템 생성 시점..

    private void Start()
    {
        //	생성 주기를 랜덤으로 설정..
        _spawnTime = Random.Range(_spawnTimeMin, _spawnTimeMax);

        //	마지막 생성 시점 초기화..
        _lastSpawnTime = 0f;
    }
    private void Update()
    {
        if(Time.time >= _lastSpawnTime + _spawnTime && _playerTransform != null)
        {
            _lastSpawnTime = Time.time;

            _spawnTime = Random.Range(_spawnTimeMin, _spawnTimeMax);

            Spawn();
        }
    }
    void Spawn()
    {
        //	플레이어 근처에서
        //	내비메시 위의 랜덤 위치 얻어오기..
        Vector3 spawnPos = GetRandomPointOnNavMesh(
            _playerTransform.position,
            _maxDist);

        //	바닥에서 0.5m 위로 세팅..
        spawnPos += Vector3.up * 0.5f;

        //	아이템 중 하나를 무작위로 선택..
        GameObject selectedItem = _items[Random.Range(0, _items.Length)];

        //	아이템 생성..
        GameObject item = Instantiate(selectedItem, spawnPos, Quaternion.identity);

        //	5초후 파괴..
        Destroy(item, 5f);
    }

    Vector3 GetRandomPointOnNavMesh(Vector3 center, float dist)
    {
        Vector3 randomPos = Random.insideUnitSphere * dist + center;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, dist, NavMesh.AllAreas);

        return hit.position;
    }
}
