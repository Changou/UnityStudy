using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    protected static GameManager _inst;
    //----------------------------
    //  BGM �� ���� ���� ����..
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
        //  ����� �ҽ� ����..
        _audioSrc = GetComponent<AudioSource>();

        //  ����� �÷���..
        _audioSrc.loop = true;
        if (_audioSrc.clip != null)
            _audioSrc.Play();
    }
}
