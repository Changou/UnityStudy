using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] _items;         //	������ ������ ������..
    public Transform _playerTransform;  //	�÷��̾� Ʈ������..
    //-----------------------------------	
    public float _maxDist = 5f;         //	�÷��̾� ��ġ���� 
                                        //	�������� ��ġ�� �ִ� �ݰ�..
    //-----------------------------------
    public float _spawnTimeMax = 7f;    //	�ִ� �ð� ����..
    public float _spawnTimeMin = 2f;    //	�ּ� �ð� ����..
    float _spawnTime;                   //	���� ����..
    float _lastSpawnTime;               //	������ ������ ���� ����..

    private void Start()
    {
        //	���� �ֱ⸦ �������� ����..
        _spawnTime = Random.Range(_spawnTimeMin, _spawnTimeMax);

        //	������ ���� ���� �ʱ�ȭ..
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
        //	�÷��̾� ��ó����
        //	����޽� ���� ���� ��ġ ������..
        Vector3 spawnPos = GetRandomPointOnNavMesh(
            _playerTransform.position,
            _maxDist);

        //	�ٴڿ��� 0.5m ���� ����..
        spawnPos += Vector3.up * 0.5f;

        //	������ �� �ϳ��� �������� ����..
        GameObject selectedItem = _items[Random.Range(0, _items.Length)];

        //	������ ����..
        GameObject item = Instantiate(selectedItem, spawnPos, Quaternion.identity);

        //	5���� �ı�..
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
