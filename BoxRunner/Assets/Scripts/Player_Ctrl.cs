using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

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
    Rigidbody _rigidbody;
    //-----------------------------
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        //  중력을 증가시켜
        //  좀 더 자연스럽게 연출..
        Physics.gravity = new Vector3(0, -25f, 0f);
    }
    //-----------------------------
    void Update()
    {
        if (_ePlayerState == ePLAYER_STATE.DEATH)
            return;

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

        _rigidbody.AddForce(new Vector3(0, _jumpPower, 0));
    }
    //-----------------------------
    void Double_Jump()
    {
        _ePlayerState = ePLAYER_STATE.D_JUMP;

        _rigidbody.AddForce(new Vector3(0, _jumpPower, 0));
    }
    //-----------------------------
    void Run()
    {
        _ePlayerState = ePLAYER_STATE.RUN;
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

    }

    void Game_Over()
    {
        _ePlayerState = ePLAYER_STATE.DEATH;
    }

    private void OnTriggerEnter(Collider other)
    {
        _rigidbody.WakeUp();

        if (other.CompareTag("Coin"))
        {
            Get_Coin();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Death Zone"))
            Game_Over();
    }
}
