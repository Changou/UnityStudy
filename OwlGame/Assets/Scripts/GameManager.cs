using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    protected static GameManager _inst;
    //----------------------------
    //  BGM 및 게임 오버 음악..
    protected AudioSource _audioSrc;
    //----------------------------
    protected virtual void Awake()
    {
        _inst = this;
        InitData();
    }
    //---------------------------
    void InitData()
    {
        //  오디오 소스 참조..
        _audioSrc = GetComponent<AudioSource>();

        //  배경음 플레이..
        _audioSrc.loop = true;
        if (_audioSrc.clip != null)
            _audioSrc.Play();
    }
}
