using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun _gun;
    PlayerInput _playerInput;

    public Transform _trsfGunPivot;

    public Transform _trsfLHandMount;
    public Transform _trsfRHandMount;

    Animator _playerAnimator;

    //Quiz
    public GameObject[] _guns;

    public enum GUN_TYPE
    {
        GUN,
        PISTOL,
        RPG,
        RIFLE,
        NONE
    }

    public GUN_TYPE _gType = GUN_TYPE.GUN;
    GUN_TYPE _ipType;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<Animator>();

    }

    void OnEnable() { _gun.gameObject.SetActive(true); }
    private void OnDisable() { _gun.gameObject.SetActive(false); }

    private void Update()
    {
        /*//  입력 컨트롤에서 총 발사..
        if (_playerInput.Fire)
        {
            //  총이 발사처리..
            _gun.Fire();
        }
        //  입력 컨트롤에서 재장전..
        else if (_playerInput.Reload)
        {
            //  총이 재장전 처리..
            if (_gun.Reload())
            {
                //  재장전 애니메이션 재생..
                _playerAnimator.SetTrigger("Reload");
            }

        }// else if (_playerInput.Reload)*/

        InputChange();

        //  남은 탄알 UI 갱신..
        UpdateUI();
    }

    void InputChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _ipType = GUN_TYPE.GUN;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            _ipType = GUN_TYPE.PISTOL;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            _ipType = GUN_TYPE.RPG;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            _ipType = GUN_TYPE.RIFLE;
        else
            _ipType = GUN_TYPE.NONE;

        if(_ipType != _gType && _ipType != GUN_TYPE.NONE)
        {
            _gType = _ipType;
            ChangeGun();
        }
    }

    void ChangeGun()
    {
        for(int i = 0;i<_guns.Length;i++)
        {
            if (i == (int)_gType) _guns[i].gameObject.SetActive(true);
            else _guns[i].gameObject.SetActive(false);
        }
        GunTransform gunT = _guns[(int)_gType].GetComponent<GunTransform>();

        gunT.SetTransform(out _trsfGunPivot, out _trsfLHandMount, out _trsfRHandMount);
    }

    void UpdateUI()
    {
        //  JUIManager 구현후 처리..
        //if (_gun != null && UIManager.Instance != null)
        //    UIManager.Instance.UpdateAmmoText(_gun._magAmmo, _gun._ammoRemain);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _trsfGunPivot.position = _playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        //  왼손의 IK 위치 가중치를
        //  타겟에 100% 적용..
        _playerAnimator.SetIKPositionWeight(
            AvatarIKGoal.LeftHand, 1f);

        //  왼손의 IK 회전 가중치를
        //  타겟에 100% 적용..
        _playerAnimator.SetIKRotationWeight(
            AvatarIKGoal.LeftHand, 1f);

        //  왼손의 IK 위치 타겟설정..
        _playerAnimator.SetIKPosition(
            AvatarIKGoal.LeftHand,
            _trsfLHandMount.position);
        //  왼손의 IK 회전 타겟설정..
        _playerAnimator.SetIKRotation(
            AvatarIKGoal.LeftHand,
            _trsfLHandMount.rotation);

        //  IK를 사용하여
        //  오른손의 위치와 회전을
        //  총의 오른쪽 기준점에 맞춤..
        _playerAnimator.SetIKPositionWeight(
            AvatarIKGoal.RightHand, 1f);

        _playerAnimator.SetIKRotationWeight(
            AvatarIKGoal.RightHand, 1f);

        _playerAnimator.SetIKPosition(
            AvatarIKGoal.RightHand,
            _trsfRHandMount.position);

        _playerAnimator.SetIKRotation(
            AvatarIKGoal.RightHand,
            _trsfRHandMount.rotation);
    }
}
