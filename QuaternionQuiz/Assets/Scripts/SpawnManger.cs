using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public static SpawnManger i;

    [Header("스폰위치")] 
    [SerializeField] float max;
    [SerializeField] float min;

    [Header("포인트")]
    [SerializeField] GameObject prefab;

    [Header("아이템"), SerializeField] GameObject[] itemPrefabs;


    [Header("몬스터 스폰"), SerializeField] GameObject monPrefab;

    [Header("딜레이")]
    [SerializeField] float spawnPointDelay;
    [SerializeField] float spawnItemDelay;

    float tmp_max;
    float tmp_min;

    private void Awake()
    {
        i = this;
        tmp_max = max;
        tmp_min = min;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MonsterSpawn());
        StartCoroutine(ItemSpawn());
        StartCoroutine(Spawn());
        StageUp();
    }

    public void ReStart()
    {
        StartCoroutine(MonsterSpawn());
        StartCoroutine(ItemSpawn());
        StartCoroutine(Spawn());
    }

    public void StageUp()
    {
        max = tmp_max;
        min = tmp_min;
        switch(StageManager.i.CurrentStage)
        {
            case 2:
                max *= 3;
                min *= 3;
                break;
            case 3:
                max *= 4;
                min *= 4;
                break;
            default:
                break;
        }
    }

    IEnumerator ItemSpawn()
    {
        while (GameManager.i.isGameOver)
        {
            yield return new WaitForSeconds(spawnItemDelay);
            GameObject item = Instantiate(itemPrefabs[Random.Range(0,itemPrefabs.Length)]);
            item.transform.position = RandomPosition();
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
        float ranX = Mathf.Floor(Random.Range(min, max) * 10f) / 10f;
        float ranZ = Mathf.Floor(Random.Range(min, max) * 10f) / 10f;

        return new Vector3(ranX, 0.3f, ranZ);
    }
}
