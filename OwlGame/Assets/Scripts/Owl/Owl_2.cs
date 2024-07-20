using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_2 : Owl
{
    //------------------------
    [Header("[ 지면 체크 ]"), SerializeField]
    Transform _checkPt;
    //------------------------
    public float _moveSpeed = 8f;
    public float _jumpSpeed = 12f;
    public float _gravity = 19f;
    public float _checkDist = 0.3f;
    //------------------------
    protected Vector3 _moveDir;
    protected bool _isDead = false;
    //------------------------
    protected virtual void OnDead() { }
    //------------------------
    //  이동 처리..
    protected virtual void MoveOwl()
    {
        //  화면 아래를 벗어났는지 체크..
        Vector2 scrPos = Camera.main.WorldToScreenPoint(transform.position);

        if (scrPos.y < -100)
        {
            _isDead = true;

            OnDead();

            return;
        }

        //  키 입력..
        float dirValue = Input.GetAxis("Horizontal");

        //  화면 좌우 가장자리인지 체크..
        if ((dirValue < 0 && scrPos.x < 40) ||
            (dirValue > 0 && scrPos.x > Screen.width - 40))
            dirValue = 0f;

        _moveDir.x = dirValue * _moveSpeed;

        //  중력..
        _moveDir.y -= _gravity * Time.deltaTime;

        //  이동..
        transform.Translate(_moveDir * Time.deltaTime);

        //  애니메이션..
        _anim.SetFloat("velocity", _moveDir.y);

    }// void MoveOwl()
    //------------------------
    //  나뭇가지 체크..
    bool _isBranch = false;
    public bool _IsBranch => _isBranch;
    bool CheckBranch()
    {
        //  체크 포인트에서
        //  아래방향으로 레이캐스팅..
        RaycastHit2D hit = Physics2D.Raycast(
            _checkPt.position,
            Vector2.down,
            _checkDist);


        _isBranch = false;
        //  낙하 중 && 나뭇가지 충돌..
        //  ->  점프..
        Color rayColor = Color.red;
        if (hit.collider != null &&
            _moveDir.y < 0 &&
            hit.collider.CompareTag("Branch"))
        {
            _moveDir.y = _jumpSpeed + ItemManager.i._JumpEffect;
            _isBranch = true;
        }
        else
            rayColor = Color.blue;

        Debug.DrawRay(
            _checkPt.position,
            Vector2.down * _checkDist,
            rayColor);

        return _isBranch;

    }// protected bool CheckBranch()

    //슈퍼점프
    [Header("슈퍼 점프 파워"), SerializeField] float _SJPower = 100f;
    public void SJump(float time)
    {
        float _DefaultSpeed;
        _DefaultSpeed = _jumpSpeed;
        _jumpSpeed = _SJPower;
        StartCoroutine(SJTime(time, _DefaultSpeed));
    }

    IEnumerator SJTime(float time, float speed)
    {
        yield return new WaitForSeconds(time);
        _jumpSpeed = speed;
    }

    //------------------------
    protected override void Update()
    {
        if (_isDead)
            return;

        if (GameManager_2._Inst._IsPause)
            return;

        CheckBranch();
        MoveOwl();
    }
}
