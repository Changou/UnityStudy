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
    [Header("������ �÷��̾�"), SerializeField]
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

            //  ī�޶� ��������
            //  �ε巯�� ��ȯ..
            _cam.orthographicSize = Mathf.Lerp(
                _cam.orthographicSize,
                _camSize,
                Time.deltaTime * _zoomSpeed);

            //  ī�޶� ��������
            //  ���� ����..
            _cam.orthographicSize = Mathf.Clamp(
                _cam.orthographicSize,
                _minSize,
                _maxSize);

        }// if (_cam != null)

    }
}
