using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MoveCtrl
{
    [SerializeField] float _stopDelay = 1f;

    [SerializeField] bool _arrive = false;

    Coroutine _cor;
    protected override void Move_By_WayPts()
    {
        //  방향 벡터 계산..
        //  -   현재 위치
        //      ->  다음 웨이 포인트 위치..
        Vector3 dir = _wayPts[_nextWayptIdx].position - _myTransf.position;

        if (_nextWayptIdx == 1)
        {
            _moveSpeed = 5f;
        }
        else
            _moveSpeed = 3f;

        //  앞 방향으로 이동..
        if (!_arrive)
            transform.position += dir.normalized * Time.deltaTime * _moveSpeed;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WAYPOINT"))
        {
            _nextWayptIdx = (++_nextWayptIdx >= _wayPts.Length) ? 1 : _nextWayptIdx;
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        _arrive = true;
        yield return new WaitForSeconds(_stopDelay);
        _arrive = false;
    }
}
