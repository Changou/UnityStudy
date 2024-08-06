using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GUN_TYPE
{
    GUN,
    PISTOL,
    RPG,
    RIFLE,
    NONE
}

public class PlayerShooter : MonoBehaviour
{
    public Gun _gun;
    public RPG _rpg;
    PlayerInput _playerInput;

    public Transform _trsfGunPivot;

    public Transform _trsfLHandMount;
    public Transform _trsfRHandMount;

    Animator _playerAnimator;

    //Quiz
    public GameObject[] _guns;

    public GUN_TYPE _gType;

    private void Awake()
    {
        _gType = LobbyManager._Inst._type;

        if(_gType == GUN_TYPE.RPG)
            _rpg = _guns[(int)_gType].transform.GetChild(0).GetComponent<RPG>();
        else
            _gun = _guns[(int)_gType].transform.GetChild(0).GetComponent<Gun>();
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<Animator>();
        ChangeGun();
    }

    private void Update()
    {
        //  �Է� ��Ʈ�ѿ��� �� �߻�..
        if (_playerInput.Fire)
        {
            //  ���� �߻�ó��..
            if(_gType == GUN_TYPE.RPG)
                _rpg.Fire();
            else
                _gun.Fire();

        }
        //  �Է� ��Ʈ�ѿ��� ������..
        else if (_playerInput.Reload)
        {
            if (_rpg != null && _rpg.Reload())
                _playerAnimator.SetTrigger("Reload");
            //  ���� ������ ó��..
            else if (_gun.Reload())
            {
                //  ������ �ִϸ��̼� ���..
                _playerAnimator.SetTrigger("Reload");
            }
           
        }// else if (_playerInput.Reload)

        //  ���� ź�� UI ����..
        UpdateUI();
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
        //UIManager ������ ó��..
        if (_gun != null && UIManager.Instance != null)
            UIManager.Instance.UpdateAmmoText(_gun._magAmmo, _gun._ammoRemain);
        else
            UIManager.Instance.UpdateAmmoText(_rpg._magAmmo, _rpg._ammoRemain);
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
