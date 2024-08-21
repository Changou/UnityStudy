using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankTextMove : MonoBehaviour
{
    [SerializeField] CAR_TYPE _lineCar;
    [SerializeField] float _speed;
    [SerializeField] Vector3 _defaultPosition;
    TextMeshPro _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();
        _defaultPosition = transform.position;
    }
    private void Start()
    {
        GameManager2._Inst._GameResetEvent += () =>
        {
            transform.position = _defaultPosition;
        };
    }

    private void Update()
    {
        if (GameManager2._Inst._carRanks.Contains(_lineCar))
        {
            _text.text = (GameManager2._Inst._carRanks.FindIndex(x => x == _lineCar) + 1).ToString();

            if (transform.position.y >= 1) return;

            transform.position += Vector3.up * _speed;
        }
    }
}
