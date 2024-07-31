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
        /*//  �Է� ��Ʈ�ѿ��� �� �߻�..
        if (_playerInput.Fire)
        {
            //  ���� �߻�ó��..
            _gun.Fire();
        }
        //  �Է� ��Ʈ�ѿ��� ������..
        else if (_playerInput.Reload)
        {
            //  ���� ������ ó��..
            if (_gun.Reload())
            {
                //  ������ �ִϸ��̼� ���..
                _playerAnimator.SetTrigger("Reload");
            }

        }// else if (_playerInput.Reload)*/

        InputChange();

        //  ���� ź�� UI ����..
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
        //  JUIManager ������ ó��..
        //if (_gun != null && UIManager.Instance != null)
        //    UIManager.Instance.UpdateAmmoText(_gun._magAmmo, _gun._ammoRemain);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _trsfGunPivot.position = _playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        //  �޼��� IK ��ġ ����ġ��
        //  Ÿ�ٿ� 100% ����..
        _playerAnimator.SetIKPositionWeight(
            AvatarIKGoal.LeftHand, 1f);

        //  �޼��� IK ȸ�� ����ġ��
        //  Ÿ�ٿ� 100% ����..
        _playerAnimator.SetIKRotationWeight(
            AvatarIKGoal.LeftHand, 1f);

        //  �޼��� IK ��ġ Ÿ�ټ���..
        _playerAnimator.SetIKPosition(
            AvatarIKGoal.LeftHand,
            _trsfLHandMount.position);
        //  �޼��� IK ȸ�� Ÿ�ټ���..
        _playerAnimator.SetIKRotation(
            AvatarIKGoal.LeftHand,
            _trsfLHandMount.rotation);

        //  IK�� ����Ͽ�
        //  �������� ��ġ�� ȸ����
        //  ���� ������ �������� ����..
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
