using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("�� ������"), SerializeField]
    GameObject _prefab;

    [Header("���� ��ġ"), SerializeField]
    Transform _spawnPos;

    [Header("���� ����"), SerializeField]
    float _MaxY;

    [Header("���� ������"), SerializeField]
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
