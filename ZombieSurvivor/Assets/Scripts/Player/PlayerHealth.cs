using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    //----------------------------------
    public Slider _healthSlider;        //	ü�� ǥ�� UI �����̴�..

    public AudioClip _acDeath;          //	��� ȿ����..		Woman Die.ogg
    public AudioClip _acHitClip;        //	�ǰ� ȿ����..		Woman Damage.ogg
    public AudioClip _acItemPickupClip; //	������ ���� ȿ����..	Pickup Clip.ogg
    AudioSource _audioSrc;              //	�÷��̾� �Ҹ� �����..
    Animator _animator;                 //	�÷��̾��� �ִϸ�����..

    PlayerMovement _playerMovement;    //	�÷��̾� ������..
    PlayerShooter _playerShooter;      //	�÷��̾� ����..	

    void Awake()
    {
        //	����� ������Ʈ ĳ��..
        _animator = GetComponent<Animator>();
        _audioSrc = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooter = GetComponent<PlayerShooter>();
    }
    protected override void OnEnable()
    {
        //	JLivingEntity��
        //	OnEnable()( ���� �ʱ�ȭ )..
        //	-	Health�� ����
        //		_startingHealth���� ������..
        base.OnEnable();

        //	ü�� �����̴� Ȱ��ȭ..
        _healthSlider.gameObject.SetActive(true);

        //	ü�� �����̴��� �ִ밪��
        //	�⺻ ü������ ����..
        _healthSlider.maxValue = _startingHealth;

        //	ü�� �����̴��� ���� ���� ü�°����� ����..
        _healthSlider.value = Health;

        //	�÷��̾� �̵� ó�� Ȱ��ȭ..
        _playerMovement.enabled = true;

        //	�� �߻� ó�� Ȱ��ȭ..
        _playerShooter.enabled = true;
    }
    public override void RestoreHealth(float newHealth)
    {
        //	JLivingEntity��
        //	RestoreHealth()( ü�� ���� )..
        base.RestoreHealth(newHealth);

        //	ü�°��� �����̴��� ����..
        _healthSlider.value = Health;
    }
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        //	�׾����� üũ..
        if (IsDead)
            return;

        //	ȿ���� ����..
        _audioSrc.PlayOneShot(_acHitClip);

        //	JLivingEntity��
        //	OnDamage()( ������ ���� )..
        base.OnDamage(damage, hitPoint, hitNormal);

        //	ü�°��� �����̴��� ����..
        _healthSlider.value = Health;

        //	�ǰ� �������� ȸ��..
        transform.rotation = Quaternion.LookRotation(hitNormal);
    }
    public override void Die()
    {
        //	JLivingEntity�� Die()( ��� ���� )..
        base.Die();

        //	ü�� �����̴� ��Ȱ��ȭ..
        _healthSlider.gameObject.SetActive(false);

        //	��� ȿ���� ���..
        _audioSrc.PlayOneShot(_acDeath);

        //	�ִϸ�������
        //	Die Ʈ���� �ߵ�,
        //	��� �ִ� ���..
        _animator.SetTrigger("Die");

        //	�÷��̾� �̵� ó�� ��Ȱ��ȭ..
        _playerMovement.enabled = false;

        //	�� �߻� ó�� ��Ȱ��ȭ..
        _playerShooter.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //	�����۰� �浹�� ���
        //	�ش� ������ ��� ó��..

        if (IsDead)
            return;

        //	�浹�� ������Ʈ�� ���������� üũ..
        if (other.TryGetComponent(out IItem item) == false)
            return;

        //	�������̸� ���..
        item.Use(gameObject);

        //	ȿ���� ����..
        _audioSrc.PlayOneShot(_acItemPickupClip);

    }
}
