using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner i;

    [Header("[스폰 위치]"),SerializeField]
    public float _posX;
    public float _posZ;

    [Header("[플레이어]"), SerializeField]
    Snake _snake;

    [Header("[몬스터]")]
    [SerializeField] GameObject _MonPrefab;
    [SerializeField] float _MSpawnDelay;

    [Header("[아이템]")]
    [SerializeField] GameObject[] _ItemPrefabs;
    [SerializeField] float _ISpawnDelay;

    List<Monster> monsters = new List<Monster>();

    private void Awake()
    {
        i = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMon());
        StartCoroutine(SpawnItem());
    }

    public void ListMonster()
    {
        foreach(Monster m in monsters) { m.Freeze(); }
    }

    IEnumerator SpawnItem()
    {
        while (!_snake._IsDead)
        {
            yield return new WaitForSeconds(_ISpawnDelay);
            Vector3 pos = new Vector3(Random.Range(-_posX, _posX), 0, Random.Range(-_posZ, _posZ));
            GameObject monster = Instantiate(_ItemPrefabs[Random.Range(0,_ItemPrefabs.Length)]);
            monster.transform.position = pos;
        }
    }

    IEnumerator SpawnMon()
    {
        while (!_snake._IsDead)
        {
            yield return new WaitForSeconds(_MSpawnDelay);
            Vector3 pos = new Vector3(Random.Range(-_posX, _posX), 0, Random.Range(-_posZ, _posZ));
            GameObject monster = Instantiate(_MonPrefab);
            monster.transform.position = pos;
            monsters.Add(monster.GetComponent<Monster>());
        }
    }
}
