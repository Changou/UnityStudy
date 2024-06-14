using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    [SerializeField] Text timeT;
    [SerializeField] Text scoreT;
    [SerializeField] Text overT;
    [SerializeField] Button btn;

    [Header("시간제한(초)"), SerializeField] float time;

    [SerializeField] float flashDelay;
    
    float curTime;
    int score;
    bool warningT = true;

    public bool isGameOver;

    private void Awake()
    {
        i = this;
        isGameOver = true;
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeT.text = string.Format("{00:N2}", time);
        scoreT.text = "점수 : " + score;
        StartCoroutine(StartTimer());
    }

    public void GameOver()
    {
        isGameOver = false;
        overT.gameObject.SetActive(true);
        btn.gameObject.SetActive(true);
        StopAllCoroutines();
    }

    public void GameClear()
    {
        isGameOver = false;
        overT.gameObject.SetActive(true);
        overT.text = "CLEAR!!";
        btn.gameObject.SetActive(true);
        StopAllCoroutines();
    }

    public void NextStage()
    {
        StageManager.i.Next();
        SpawnManger.i.StageUp();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            if(curTime <= 10 && curTime > 0 && warningT)
            {
                StartCoroutine(Flash());
            }
            if (curTime <= 0)
            {
                warningT = true;
                timeT.color = Color.black;
                curTime = 0;
                GameClear();
                yield break;
            }
        }
    }

    IEnumerator Flash()
    {
        warningT = false;
        while (!warningT)
        {
            timeT.color = Color.white;
            yield return new WaitForSeconds(flashDelay);
            timeT.color = Color.red;
            yield return new WaitForSeconds(flashDelay);
        }
    }
    public void AddScore()
    {
        score++;
        scoreT.text = "점수 : " + score;
    }
}
