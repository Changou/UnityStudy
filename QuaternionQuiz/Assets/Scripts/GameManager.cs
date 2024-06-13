using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager i;

    [SerializeField] Text timeT;
    [SerializeField] Text scoreT;
    [SerializeField] Text overT;
    
    [Header("시간제한(분)"), SerializeField] float time;
    
    float curTime;
    int minute;
    int second;
    int score;

    public bool isGameOver;

    private void Awake()
    {
        i = this;
        isGameOver = true;
        score = 0;
        StartCoroutine(StartTimer());
    }

    // Start is called before the first frame update
    void Start()
    {
        timeT.text = time.ToString("00") + ":00";
        scoreT.text = "점수 : " + score;
    }

    void GameOver()
    {
        isGameOver = false;
        overT.gameObject.SetActive(true);
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1f);
        time *= 60;
        curTime = time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            timeT.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if (curTime <= 0)
            {
                Debug.Log("시간 종료");
                curTime = 0;
                GameOver();
                yield break;
            }
        }
    }

    public void AddScore()
    {
        score++;
        scoreT.text = "점수 : " + score;
    }
}
