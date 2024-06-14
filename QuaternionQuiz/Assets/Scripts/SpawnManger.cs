using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public static SpawnManger i;

    [Header("스폰위치")] 
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    [SerializeField] float maxX;
    [SerializeField] float minX;

    [Header("포인트")]
    [SerializeField] GameObject prefab;

    [Header("아이템"), SerializeField] GameObject[] itemPrefabs;


    [Header("몬스터 스폰"), SerializeField] GameObject monPrefab;

    [Header("딜레이")]
    [SerializeField] float spawnPointDelay;
    [SerializeField] float spawnItemDelay;

    private void Awake()
    {
        i = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MonsterSpawn());
        StartCoroutine(ItemSpawn());
        StartCoroutine(Spawn());
    }

    public void StageUp()
    {
        if(StageManager.i.CurrentStage == 2)
        {
            maxX *= 3;
            minX *= 3;
            maxZ *= 3;
            minZ *= 3;
        }
        else if(StageManager.i.CurrentStage == 3)
        {
            maxX *= 4;
            minX *= 4;
            maxZ *= 4;
            minZ *= 4;
        }
    }

    IEnumerator ItemSpawn()
    {
        while (GameManager.i.isGameOver)
        {
            yield return new WaitForSeconds(spawnItemDelay);
            GameObject point = Instantiate(itemPrefabs[Random.Range(0,itemPrefabs.Length)]);
            point.transform.position = RandomPosition();
        }
    }

    IEnumerator MonsterSpawn()
    {
        yield return new WaitForSeconds(1f);
        GameObject monster = Instantiate(monPrefab);
        monster.transform.position = RandomPosition();
    }

    IEnumerator Spawn()
    {
        while (GameManager.i.isGameOver)
        {
            yield return new WaitForSeconds(spawnPointDelay);
            GameObject point = Instantiate(prefab);
            point.transform.position = RandomPosition();
        }
    }

    Vector3 RandomPosition()
    {
        float ranX = Mathf.Floor(Random.Range(minX, maxX) * 10f) / 10f;
        float ranZ = Mathf.Floor(Random.Range(minX, maxX) * 10f) / 10f;

        return new Vector3(ranX, 0.3f, ranZ);
    }
}
