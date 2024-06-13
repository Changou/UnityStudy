using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [Header("������ġ")] 
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    [SerializeField] float maxX;
    [SerializeField] float minX;

    [Header("������")]
    [SerializeField] GameObject prefab;

    [Header("������")]
    [SerializeField] float spawnDelay;

    bool isSpawn = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (isSpawn)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject item = Instantiate(prefab);
            item.transform.position = RandomPosition();
            Destroy(item, 5f);
        }
    }

    Vector3 RandomPosition()
    {
        float ranX = Mathf.Floor(Random.Range(minX, maxX) * 10f) / 10f;
        float ranZ = Mathf.Floor(Random.Range(minX, maxX) * 10f) / 10f;

        return new Vector3(ranX, 0.4f, ranZ);
    }
}
