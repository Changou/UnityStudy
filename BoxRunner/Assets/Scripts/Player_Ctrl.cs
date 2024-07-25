using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Events;

public class Player_Ctrl : MonoBehaviour
{
    //-----------------------------
    //  플레이어 상태..
    public enum ePLAYER_STATE
    {
        RUN,
        JUMP,
        D_JUMP,
        DEATH
    }
    //-----------------------------
    //  플레이어의 현재 상태..
    public ePLAYER_STATE _ePlayerState = ePLAYER_STATE.RUN;
    //-----------------------------
    [Header("점프력"), SerializeField]
    float _jumpPower = 500f;
    //-----------------------------
    public enum eSOUND
    {
        COIN,
        DEATH,
        JUMP
    }
    [Header("효과음"), SerializeField]
    AudioClip[] _sounds;

    AudioSource _audioSrc;

    void Play_Sound(eSOUND eIdx, float volume = 0.7f)
    {
        _audioSrc.PlayOneShot(_sounds[(int)eIdx], volume);
    }

    Rigidbody _rigidbody;
    //-----------------------------
    [Header("애니메이션 컨트롤러"), SerializeField]
    Animator _animCtrl;
    //-----------------------------
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _audioSrc = GetComponent<AudioSource>();
        _audioSrc.playOnAwake = false;

        //  중력을 증가시켜
        //  좀 더 자연스럽게 연출..
        Physics.gravity = new Vector3(0, -25f, 0f);
    }
    //-----------------------------
    void Update()
    {
        if (_ePlayerState == ePLAYER_STATE.DEATH)
            return;

        if (Application.platform == RuntimePlatform.Android ||
             Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (_ePlayerState == ePLAYER_STATE.JUMP)
                        Double_Jump();

                    if (_ePlayerState == ePLAYER_STATE.RUN)
                        Jump();

                }// if(touch.phase == TouchPhase.Began )

            }// if( Input.touchCount > 0 )
        }

            if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_ePlayerState)
            {
                case ePLAYER_STATE.JUMP:
                    Double_Jump(); break;

                case ePLAYER_STATE.RUN:
                    Jump(); break;

            }// switch(_ePlayerState)

        }// if (Input.GetKeyDown(KeyCode.Space))

    }// void Update()
    //-----------------------------
    void Jump()
    {
        _ePlayerState = ePLAYER_STATE.JUMP;

        Play_Sound(eSOUND.JUMP);

        _rigidbody.AddForce(new Vector3(0, _jumpPower, 0));

        _animCtrl.SetTrigger("Jump");
        _animCtrl.SetBool("Ground", false);
    }
    //-----------------------------
    void Double_Jump()
    {
        _ePlayerState = ePLAYER_STATE.D_JUMP;

        Play_Sound(eSOUND.JUMP);

        _rigidbody.AddForce(new Vector3(0, _jumpPower, 0));

        _animCtrl.SetTrigger("D_Jump");
        _animCtrl.SetBool("Ground", false);
    }
    //-----------------------------
    void Run()
    {
        _ePlayerState = ePLAYER_STATE.RUN;

        _animCtrl.SetBool("Ground", true);
    }
    //-----------------------------
    void OnCollisionEnter(Collision collision)
    {
        if (_ePlayerState == ePLAYER_STATE.RUN) return;
        if (_ePlayerState == ePLAYER_STATE.DEATH) return;

        Run();
    }

    void Get_Coin()
    {
        Play_Sound(eSOUND.COIN);
    }

    void Game_Over()
    {
        _ePlayerState = ePLAYER_STATE.DEATH;

        Play_Sound(eSOUND.DEATH);
    }

    private void OnTriggerEnter(Collider other)
    {
        _rigidbody.WakeUp();
        if (other.CompareTag("Coin"))
        {
            Get_Coin();
            _onGetCoin.Invoke();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Death Zone"))
        {
            Game_Over();
            _onGameOver.Invoke();
        }
    }

    public UnityEvent _onGetCoin;
    public UnityEvent _onGameOver;
}
