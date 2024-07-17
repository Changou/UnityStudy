using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField, Header("[ 점수 텍스트 ]")]
    TextMeshProUGUI _textScore;

    [SerializeField, Header("[ 이동 속도 ]")]
    float _speed = 1f;
    //--------------------------------
    void Start()
    {
        StartCoroutine(CRT_FadeOut());
    }
    //--------------------------------
    void Update()
    {
        float amount = _speed * Time.deltaTime;
        transform.Translate(Vector3.up * amount);
    }
    //--------------------------------
    IEnumerator CRT_FadeOut()
    {
        yield return new WaitForSeconds(1);

        Color col = _textScore.color;

        for (float alpha = 1f; alpha > 0; alpha -= 0.02f)
        {
            col.a = alpha;
            _textScore.color = col;

            yield return null;
        }

        Destroy(gameObject);

    }// IEnumerator CRT_FadeOut()
    //--------------------------------
    public void SetScore(int score)
    {
        _textScore.text = score.ToString("+0; -0");
        if (score < 0)
            _textScore.color = Color.red;

    }
}
