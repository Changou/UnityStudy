using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("아이템")]
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spawnDelay;

    [Header("스폰지역")]
    [SerializeField] float max;
    [SerializeField] float min;

    bool isWhile = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (isWhile) {
            yield return new WaitForSeconds(spawnDelay);
            GameObject item = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            item.transform.position = RandomPosition();
        }
    }

    Vector3 RandomPosition()
    {
        float ranX = Mathf.Floor(Random.Range(min, max) * 10f) / 10f;
        float ranZ = Mathf.Floor(Random.Range(min, max) * 10f) / 10f;

        return new Vector3(ranX, 0.1f, ranZ);
    }
}
