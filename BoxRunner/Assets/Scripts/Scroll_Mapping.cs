using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Mapping : MonoBehaviour
{
    [Header("스크롤 속도"), SerializeField]
    float _scrollSpeed = 0.5f;

    float _targetOffset;

    Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _targetOffset += _scrollSpeed * Time.deltaTime;

        _renderer.material.mainTextureOffset = new Vector2(_targetOffset, 0f);
    }

}
