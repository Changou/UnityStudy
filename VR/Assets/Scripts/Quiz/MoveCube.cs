using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MoveCtrl
{
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
        _myTransf.Translate(dir.normalized * Time.deltaTime * _moveSpeed);

    }
}
