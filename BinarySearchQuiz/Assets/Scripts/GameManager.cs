using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField] int area;

    [SerializeField] string[] names;

    [Header("[ lv 범위 ]"), SerializeField, Range(1, 50)]
    int _rangeLv = 1;
    [Header("[ hp 범위 ]"), SerializeField, Range(10, 100)]
    int _rangeHp = 100;
    [Header("[ attack 범위 ]"), SerializeField, Range(5, 50)]
    int _rangeAttack = 10;

    [Header("검색 값"), SerializeField] int _SearchHp = 0;
    [SerializeField] float speed;

    Sphere[] _SphereInfo = new Sphere[100];

    Vector3 backPosition = new Vector3();

    int GetRandom(int range) { int res = Random.Range(0, range); return res; }

    bool isMove = false;
    bool isBack = true;
    Coroutine moveCor;
    int searchIdx;

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
            _SphereInfo[i] = sphere.GetComponent<Sphere>();
        }
        Sort();
        backPosition = Camera.main.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isBack)
        {
            searchIdx = Search(_SphereInfo, _SearchHp);
            Debug.Log("First Index of Attack [ " + _SearchHp + " ] ==> " + searchIdx);
            if (searchIdx < 0)
                Debug.Log("해당 오브젝트가 없습니다.");
            else
            {
                isMove = true;
                isBack = false;
                moveCor = StartCoroutine(MoveDelay());
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && moveCor == null)
        {
            Camera.main.transform.position = backPosition;
            isBack = true;
        }
        if (isMove)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, _SphereInfo[searchIdx].transform.position + new Vector3(0, 2, -7), speed * Time.deltaTime);
        }
    }

    IEnumerator MoveDelay() 
    {
        yield return new WaitForSeconds(2f);
        isMove = false;
        moveCor = null;
    }

    int Search(Sphere[] arr, int searchHp)
    {
        int startIdx = 0;
        int endIdx = arr.Length - 1;
        int findIdx = -1;

        while (startIdx <= endIdx)
        {
            int midIdx = (int)((startIdx + endIdx) * 0.5f);

            if (searchHp > arr[midIdx]._Hp)
                startIdx = midIdx + 1;
            else if (searchHp < arr[midIdx]._Hp)
                endIdx = midIdx - 1;
            else
            {
                findIdx = midIdx;
                break;
            }

        }
        return findIdx;
    }

    void Sort()
    {
        for(int idx =1; idx < _SphereInfo.Length; ++idx)
        {
            for(int subIdx = idx -1; subIdx >= 0;--subIdx)
            {
                if (_SphereInfo[subIdx]._Hp > _SphereInfo[subIdx + 1]._Hp)
                    Swap(ref _SphereInfo[subIdx], ref _SphereInfo[subIdx + 1]);

                else break;
            }
        }
    }

    void Swap(ref Sphere a, ref Sphere b)
    {
        Sphere tmp = a;
        a = b;
        b = tmp;
    }
}
