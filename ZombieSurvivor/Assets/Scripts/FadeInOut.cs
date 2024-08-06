using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    //--------------------------
    [Header("���̵� �� / �ƿ��� ����� �̹���"), SerializeField]
    Image _fadeImage;

    [Header("���̵� ����"), SerializeField]
    float _rate = 0.2f;
    //--------------------------

    [Header("�� �ε�"), SerializeField]
    SceneLoader _sceneLoader;

    void Awake()
    {
        _fadeImage.color = Color.black;
    }
    //--------------------------
    IEnumerator CRT_FadeInOut(bool isFadeIn, float rate, string name = "")
    {
        if (isFadeIn)
        {
            Color tmp = new Color(0, 0, 0, 1);

            while (tmp.a > 0f)
            {
                tmp.a -= _rate * Time.unscaledDeltaTime;

                _fadeImage.color = tmp;

                Mathf.Clamp(tmp.a, 0f, 1f);

                yield return null;

            }// while (tmp.a > 0f)

        }// if(isFadeIn)
        else
        {
            Color tmp = new Color(0, 0, 0, _fadeImage.color.a);

            while (tmp.a < 1f)
            {
                tmp.a += _rate * Time.unscaledDeltaTime;

                _fadeImage.color = tmp;

                Mathf.Clamp(tmp.a, 0f, 1f);

                yield return null;
            }
            _sceneLoader.OnLoadScene(name);

        }// ~if(isFadeIn)

    }// IEnumerator CRT_FadeInOut(bool isIn)
    //--------------------------
    void Start()
    {
        _fadeImage.color = Color.black;

        StartCoroutine(CRT_FadeInOut(true, _rate));
    }

    public void FadeOut(string name)
    {
        StopAllCoroutines();
        StartCoroutine(CRT_FadeInOut(false, _rate, name));
    }
}