using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    //--------------------------
    [Header("페이드 인 / 아웃에 사용할 이미지"), SerializeField]
    Image _fadeImage;

    [Header("페이드 비율"), SerializeField]
    float _rate = 0.2f;
    //--------------------------
    void Awake()
    {
        _fadeImage.color = Color.black;
    }
    //--------------------------
    IEnumerator CRT_FadeInOut(bool isFadeIn, float rate)
    {
        if (isFadeIn)
        {
            Color tmp = new Color(0, 0, 0, 1);

            while (tmp.a > 0f)
            {
                tmp.a -= rate * Time.deltaTime;

                _fadeImage.color = tmp;

                Mathf.Clamp(tmp.a, 0f, 1f);

                yield return null;

            }// while (tmp.a > 0f)

        }// if(isFadeIn)
        else
        {
            Color tmp = new Color(0, 0, 0, 0);

            while (tmp.a < 1f)
            {
                tmp.a += _rate * Time.deltaTime;

                _fadeImage.color = tmp;

                Mathf.Clamp(tmp.a, 0f, 1f);

                yield return null;
            }

        }// ~if(isFadeIn)

    }// IEnumerator CRT_FadeInOut(bool isIn)
    //--------------------------
    void Start()
    {
        _fadeImage.color = Color.black;

        StartCoroutine(CRT_FadeInOut(true, _rate));
    }
}
