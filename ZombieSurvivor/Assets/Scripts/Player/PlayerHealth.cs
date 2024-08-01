using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    //----------------------------------
    public Slider _healthSlider;        //	체력 표시 UI 슬라이더..

    public AudioClip _acDeath;          //	사망 효과음..		Woman Die.ogg
    public AudioClip _acHitClip;        //	피격 효과음..		Woman Damage.ogg
    public AudioClip _acItemPickupClip; //	아이템 습득 효과음..	Pickup Clip.ogg
    AudioSource _audioSrc;              //	플레이어 소리 재생기..
    Animator _animator;                 //	플레이어의 애니메이터..

    PlayerMovement _playerMovement;    //	플레이어 움직임..
    PlayerShooter _playerShooter;      //	플레이어 슈터..	

    void Awake()
    {
        //	사용할 컴포넌트 캐싱..
        _animator = GetComponent<Animator>();
        _audioSrc = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooter = GetComponent<PlayerShooter>();
    }
    protected override void OnEnable()
    {
        //	JLivingEntity의
        //	OnEnable()( 상태 초기화 )..
        //	-	Health의 값이
        //		_startingHealth으로 설정됨..
        base.OnEnable();

        //	체력 슬라이더 활성화..
        _healthSlider.gameObject.SetActive(true);

        //	체력 슬라이더의 최대값을
        //	기본 체력으로 변경..
        _healthSlider.maxValue = _startingHealth;

        //	체력 슬라이더의 값을 현재 체력값으로 변경..
        _healthSlider.value = Health;

        //	플레이어 이동 처리 활성화..
        _playerMovement.enabled = true;

        //	총 발사 처리 활성화..
        _playerShooter.enabled = true;
    }
    public override void RestoreHealth(float newHealth)
    {
        //	JLivingEntity의
        //	RestoreHealth()( 체력 증가 )..
        base.RestoreHealth(newHealth);

        //	체력값을 슬라이더에 적용..
        _healthSlider.value = Health;
    }
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        //	죽었는지 체크..
        if (IsDead)
            return;

        //	효과음 연출..
        _audioSrc.PlayOneShot(_acHitClip);

        //	JLivingEntity의
        //	OnDamage()( 데미지 적용 )..
        base.OnDamage(damage, hitPoint, hitNormal);

        //	체력값을 슬라이더에 적용..
        _healthSlider.value = Health;

        //	피격 방향으로 회전..
        transform.rotation = Quaternion.LookRotation(hitNormal);
    }
    public override void Die()
    {
        //	JLivingEntity의 Die()( 사망 적용 )..
        base.Die();

        //	체력 슬라이더 비활성화..
        _healthSlider.gameObject.SetActive(false);

        //	사망 효과음 재생..
        _audioSrc.PlayOneShot(_acDeath);

        //	애니메이터의
        //	Die 트리거 발동,
        //	사망 애니 재생..
        _animator.SetTrigger("Die");

        //	플레이어 이동 처리 비활성화..
        _playerMovement.enabled = false;

        //	총 발사 처리 비활성화..
        _playerShooter.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //	아이템과 충돌한 경우
        //	해당 아이템 사용 처리..

        if (IsDead)
            return;

        //	충돌한 오브젝트가 아이템인지 체크..
        if (other.TryGetComponent(out IItem item) == false)
            return;

        //	아이템이면 사용..
        item.Use(gameObject);

        //	효과음 연출..
        _audioSrc.PlayOneShot(_acItemPickupClip);

    }
}
