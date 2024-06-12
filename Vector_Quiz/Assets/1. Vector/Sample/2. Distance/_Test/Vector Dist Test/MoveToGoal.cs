//===================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//===================================================================
public class MoveToGoal : MonoBehaviour
{
    //---------------------------------
    [Header("목표 지점"), SerializeField]
    Transform _goal;
    //---------------------------------
    [Header("최소 속력"), SerializeField]
    float _speedRangeMin = 3f;
    [Header("최대 속력"), SerializeField]
    float _speedRangeMax = 5f;
    //  실제 속력..
    float _speed;
    //---------------------------------
    [Header("유효거리"), SerializeField]
    float _validOffsetToGoal = 0.05f;
    //---------------------------------
    //  도달 체크..
    bool _isOver = false;
    //---------------------------------
    void Awake() {
        _isOver = false;
        _speed = Random.Range( _speedRangeMin, _speedRangeMax );

        StartCoroutine(CRT_ChangeSpeed());
    }
    //---------------------------------
    void Update()
    {
        if (_isOver)
            return;

        float remainDist = Vector3.Distance(_goal.position, transform.position);

        if (remainDist <= _validOffsetToGoal)
        {
            transform.position = _goal.position;
            _isOver = true;
        }
        
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

    }// void Update()
    //---------------------------------
    IEnumerator CRT_ChangeSpeed()
    {
        do {
            float changeTime = Random.Range(0.3f, 1.5f);

            yield return new WaitForSeconds(changeTime);

            _speed = Random.Range(_speedRangeMin, _speedRangeMax);

            if (_isOver) yield break;
        }
        while (true);
    }
    //---------------------------------

}// public class MoveToGoal : MonoBehaviour
 //===================================================================