using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    protected static GameManager _inst;
    //----------------------------
    [Header("[ 스폰 포인트 ]"), SerializeField]
    Transform _spawnPt;
    //----------------------------    
    [Header("[ 나뭇가지 프리팹 ]"), SerializeField]
    Branch _prefabBranch;
    //----------------------------
    [Header("[ 참새 프리팹 ]"), SerializeField]
    Bird _prefabBird;
    //----------------------------
    [Header("[ 선물 프리팹 ]"), SerializeField]
    Gift _prefabGift;
    //----------------------------
    //  BGM 및 게임 오버 음악..
    protected AudioSource _audioSrc;
    //----------------------------
    Vector3 _worldSize;     //  화면 크기..( 월드 좌표 )
    //----------------------------
    protected virtual void Awake()
    {
        _inst = this;
        InitData();
    }
    //----------------------------
    protected virtual void Update()
    {
        Make_Branch();
        Make_Bird();
        Make_Gift();
    }
    //----------------------------
    void InitData()
    {
        //  오디오 소스 참조..
        _audioSrc = GetComponent<AudioSource>();

        //  배경음 플레이..
        _audioSrc.loop = true;
        if (_audioSrc.clip != null)
            _audioSrc.Play();

        //  스크린 좌표..
        //  ->  월드 좌표..
        Vector3 scrSize = new Vector3(Screen.width, Screen.height);

        //  월드 좌표를 계산하려는
        //  카메라로 부터의 깊이 값..
        //  -   거리와 다른 개념..
        scrSize.z = 10;
        _worldSize = Camera.main.ScreenToWorldPoint(scrSize);

    }// void InitData()
    //----------------------------
    //  나뭇가지 만들기..
    void Make_Branch()
    {
        //  현재 생성된 나뭇가지의
        //  갯수 구하기..
        int cnt = GameObject.FindGameObjectsWithTag("Branch").Length;

        //  화면에 있는 나뭇가지의
        //  갯수가 3개를 초과하면
        //  생성 취소..
        if (cnt > 3)
            return;

        //  스폰 지점 높이에
        //  지그재그로 배치..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);

        //  나뭇가지 생성..
        GameObject branch = Instantiate(_prefabBranch.gameObject);
        branch.transform.position = pos;

        //  스폰 지점 위치 갱신..
        _spawnPt.position += new Vector3(0, 3, 0);

    }// void Make_Branch()
    //----------------------------
    void Make_Bird()
    {
        //  현재 생성된 참새의
        //  갯수 구하기..
        int cnt = GameObject.FindGameObjectsWithTag("Bird").Length;

        //  화면에 생성된 참새가
        //  7개를 초과하면
        //  생성 취소..
        if (cnt > 7)
            return;

        //  확률이 90% 미만인 경우
        //  취소..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  생성 위치 설정..
        Vector3 pos = _spawnPt.position;
        pos.y -= Random.Range(0, 5f);

        GameObject bird = Instantiate(_prefabBird.gameObject);
        bird.transform.position = pos;

    }// void Make_Bird()
    //----------------------------
    void Make_Gift()
    {
        //  생성된 선물 상자 갯수 구하기..
        int cnt = GameObject.FindGameObjectsWithTag("Gift").Length;

        //  선물이 화면에 3개 이상이면
        //  취소..
        if (cnt >= 3)
            return;

        //  확률이 90% 미만인 경우
        //  취소..
        if (Random.Range(0, 1f) < 0.9f)
            return;

        //  위치 설정..
        Vector3 pos = _spawnPt.position;
        pos.x = Random.Range(-_worldSize.x * 0.5f, _worldSize.x * 0.5f);
        pos.y += Random.Range(0.5f, 1.5f);

        //  이름 설정..
        GameObject gift = Instantiate(_prefabGift.gameObject);
        gift.name = "Gift " + Random.Range(0, 3);
        gift.transform.position = pos;
    }
}
