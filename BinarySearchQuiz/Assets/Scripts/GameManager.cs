using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField] int area;

    [SerializeField] string[] names;

    [Header("[ lv 범위 ]"), SerializeField, Range(1, 5)]
    int _rangeLv = 1;
    [Header("[ hp 범위 ]"), SerializeField, Range(10, 30)]
    int _rangeHp = 15;
    [Header("[ attack 범위 ]"), SerializeField, Range(5, 15)]
    int _rangeAttack = 10;

    int GetRandom(int range) { int res = Random.Range(0, range); return res; }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject sphere = Instantiate(prefabs);
            sphere.transform.position = new Vector3(
                Random.Range(-area, area + 1), Random.Range(-area, area + 1), Random.Range(-area, area + 1));
            string name = names[Random.Range(0, names.Length)];
            int lv = GetRandom(_rangeLv);
            int hp = GetRandom(_rangeHp);
            int attack = GetRandom(_rangeAttack);
            sphere.GetComponent<Sphere>().SetData(name, lv, hp, attack);
        }

    }

    
}
