using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    [SerializeField] Text timeT;

    [Header("시간제한(초)"), SerializeField] float time;

    float curTime;
    public bool isGameOver;

    [SerializeField] int[] killCount = new int[5];

    [SerializeField] InsertSort _InsertSort;
    private void Awake()
    {
        i = this;
        isGameOver = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeT.text = string.Format("{00:N2}", time);
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillCount(int type)
    {
        killCount[type]++;
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(0.5f);
        curTime = time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;

            timeT.text = string.Format("{00:N2}", curTime);
            yield return null;
            if (curTime <= 0)
            {
                curTime = 0;
                isGameOver = false;
                GameClear();
                yield break;
            }
        }
    }

    void GameClear()
    {
        _InsertSort.Sort(ref killCount);
        Debug.Log("킬 집계");
        for(int i = 0; i < 5; i++)
        {
            Debug.Log($"{_InsertSort._Monster[i]} : {killCount[i]}");
        }
    }
}
