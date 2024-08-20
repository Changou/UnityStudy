using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] Text _endText;
    [SerializeField] ParticleSystem[] _particles;

    [SerializeField] GameObject[] _endType;

    private void OnEnable()
    {
        IsRestartBtnOn();

        _endText.text = 
            $"½Â : {GameManager._Inst._winCnt} / ¹« : {GameManager._Inst._drawCnt} / ÆÐ : {GameManager._Inst._loseCnt}";

        int num = Max(GameManager._Inst._winCnt, GameManager._Inst._drawCnt, GameManager._Inst._loseCnt);

        _particles[num].gameObject.SetActive(true);
        _particles[num].Play();
        
        GameManager._Inst._IsgameOver = true;
    }

    void IsRestartBtnOn()
    {
        if (GameManager._Inst._isRestartOn)
        {
            _endType[1].SetActive(true);
            _endType[0].SetActive(false);
        }
        else
        {
            _endType[0].SetActive(true);
            _endType[1].SetActive(false);
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    int Max(int a, int b, int c)
    {
        int[] arr = { a, b, c };
        int max = a;
        int result = 0;
        for(int i = 1; i < arr.Length; i++)
        {
            if(max < arr[i])
            {
                max = arr[i];
                result = i;
            }
        }
        return result;
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
