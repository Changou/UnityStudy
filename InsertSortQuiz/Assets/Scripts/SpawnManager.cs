using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("몬스터")]
    [SerializeField] GameObject[] monsterPrefab;
    [SerializeField] float spawnD;

    [Header("스폰위치")]
    [SerializeField] int minX;
    [SerializeField] int maxX;
    [SerializeField] int spawnZ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (GameManager.i.isGameOver)
        {
            yield return new WaitForSeconds(spawnD);
            GameObject monster = Instantiate(monsterPrefab[Random.Range(0, monsterPrefab.Length)]);
            monster.transform.position = new Vector3(Random.Range(minX, maxX + 1), 0, spawnZ);
            monster.transform.rotation = Quaternion.Euler(0, -180f, 0);
        }
    }
}
