using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //-------------------
    Camera _cam;
    public float _zoomSpeed = 2f;
    public float _minSize = 5f;
    public float _maxSize = 7f;
    float _camSize;
    //-------------------
    [Header("추적할 플레이어"), SerializeField]
    GameObject _player;
    //-------------------
    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }
    //-------------------
    void Update()
    {
        if (_cam != null)
        {
            _camSize = 4f + _player.transform.position.y;

            //  카메라 사이즈의
            //  부드러운 변환..
            _cam.orthographicSize = Mathf.Lerp(
                _cam.orthographicSize,
                _camSize,
                Time.deltaTime * _zoomSpeed);

            //  카메라 사이즈의
            //  범위 고정..
            _cam.orthographicSize = Mathf.Clamp(
                _cam.orthographicSize,
                _minSize,
                _maxSize);

        }// if (_cam != null)

    }
}
