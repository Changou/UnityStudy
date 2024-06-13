using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [Header("스폰위치")] 
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    [SerializeField] float maxX;
    [SerializeField] float minX;

    [Header("아이템")]
    [SerializeField] GameObject prefab;

    [Header("딜레이")]
    [SerializeField] float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (GameManager.i.isGameOver)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject item = Instantiate(prefab);
            item.transform.position = RandomPosition();
        }
    }

    Vector3 RandomPosition()
    {
        float ranX = Mathf.Floor(Random.Range(minX, maxX) * 10f) / 10f;
        float ranZ = Mathf.Floor(Random.Range(minX, maxX) * 10f) / 10f;

        return new Vector3(ranX, 0.4f, ranZ);
    }
}
