using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    //----------------------------------
    [Header("[ 이동 속도.. ]"), SerializeField]
    protected float _moveSpeed = 1f;
    //----------------------------------
    [Header("[ 회전 속도.. ]"), SerializeField]
    protected float _rotSpeed = 3f;
    //----------------------------------
    [Header("[ 웨이포인트 트랙.. ]"), SerializeField]
    WayPointTrack _track;
    protected Transform[] _wayPts;
    //----------------------------------
    [Header("[ 다음 이동 타겟 웨이 포인트 인덱스..]"), SerializeField]
    protected int _nextWayptIdx = 1;
    //----------------------------------
    //  캐릭터 트랜스폼..
    protected Transform _myTransf;
    //----------------------------------
    //  유니티 이벤트 함수들도
    //  오버라이딩 가능..
    protected virtual void Awake()
    {
        _myTransf = transform;

    }// protected virtual void Awake()
    //----------------------------------
    void Start()
    {
        _wayPts = _track._WayPts;
    }
    //----------------------------------
    protected virtual void Update() { Move_By_WayPts(); }
    //----------------------------------
    protected virtual void Move_By_WayPts()
    {
        //  방향 벡터 계산..
        //  -   현재 위치
        //      ->  다음 웨이 포인트 위치..
        Vector3 dir = _wayPts[_nextWayptIdx].position - _myTransf.position;

        ////  방향 벡터의 회전 각도를
        ////  쿼터니언으로 변환..
        //Quaternion rot = Quaternion.LookRotation(dir.normalized);

        ////  회전 보간..
        //_myTransf.rotation = Quaternion.Lerp(_myTransf.rotation, rot, _rotSpeed * Time.deltaTime);

        //  앞 방향으로 이동..
        _myTransf.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);

    }// protected void Move_By_WayPts()
    //----------------------------------
    protected virtual void OnTriggerEnter(Collider other)
    {
        //  웨이포인트에 도달 하면
        //  다음 웨이포인트 인덱스 설정..
        if (other.CompareTag("WAYPOINT"))
            _nextWayptIdx = (++_nextWayptIdx >= _wayPts.Length) ? 1 : _nextWayptIdx;

    }
}
