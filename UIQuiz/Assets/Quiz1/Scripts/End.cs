using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] Text _endText;
    [SerializeField] ParticleSystem[] _particles;

    private void OnEnable()
    {
        _endText.text = 
            $"½Â : {GameManager._Inst._winCnt} / ¹« : {GameManager._Inst._drawCnt} / ÆÐ : {GameManager._Inst._loseCnt}";

        int num = Max(GameManager._Inst._winCnt, GameManager._Inst._drawCnt, GameManager._Inst._loseCnt);

        _particles[num].gameObject.SetActive(true);
        _particles[num].Play();
        
        GameManager._Inst._IsgameOver = true;
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
