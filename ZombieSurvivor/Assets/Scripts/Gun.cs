using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //	총의 상태를 표현..
    public enum eSTATE
    {
        Ready,      //	발사 준비..
        Empty,      //	탄창 소진..
        Reloading   //	재장전 중..

    }//	public enum eSTATE

    //	현재 총의 상태..
    public eSTATE _eCurState { get; protected set; }
    //----------------------------
    //	탄알이 발사될 위치..
    public Transform _fireTransf;
    //----------------------------
    //	총구 화염 이펙트..
    public ParticleSystem _muzzleFlashEffect;
    //	탄피 배출 이펙트..
    //public ParticleSystem _shellEjectEffect;
    //----------------------------
    //	탄알 궤적용 라인 렌더러..
    LineRenderer _bulletLineRenderer;
    //----------------------------
    //	총의 소리 재생기..
    protected AudioSource _gunAudioPlayer;
    //	발사 소리..
    public AudioClip _shotClip;
    //	재장전 소리..
    public AudioClip _reloadClip;
    //----------------------------
    //	공격력..
    public float _damage = 25f;
    //	사정거리..
    float _fireDist = 50;
    //----------------------------
    //	전체 탄알..
    public int _ammoRemain = 100;
    //	탄창 용량..
    public int _magCapacity = 25;
    //	현재 탄창에 남아있는 탄알..
    public int _magAmmo;
    //----------------------------
    //	탄알 발사 간격..
    public float _timeBetFire = 0.12f;
    //	재장전 소요 시간..
    public float _reloadTime = 1.8f;
    //	총을 마지막으로 발사한 시점..
    float _lastFireTime;
    //----------------------------
    protected virtual void Awake()
    {
        _gunAudioPlayer = GetComponent<AudioSource>();
        _bulletLineRenderer = GetComponent<LineRenderer>();

        _bulletLineRenderer.positionCount = 2;

        _bulletLineRenderer.enabled = false;
    }
    private void OnEnable()
    {
        //	현재 탄창 가득 채우기..
        _magAmmo = _magCapacity;

        //	현재 상태를 [ 발사 준비 ] 상태로 전환..
        _eCurState = eSTATE.Ready;

        //	마지막으로 총을 쏜 시점 초기화..
        _lastFireTime = 0f;
    }

    public void Fire()
    {
        if (_eCurState == eSTATE.Ready &&                   //	발사 대기 상태 && 
            Time.time >= _lastFireTime + _timeBetFire)      //	마지막 발사 시점부터 timeBetFire 이상의 시간이 지났는지 체크..
        {
            _lastFireTime = Time.time;
            Shot();
        }
    }

    protected virtual void Shot()
    {
        RaycastHit hit;

        Vector3 hitPos = Vector3.zero;

        if (Physics.Raycast(_fireTransf.position, _fireTransf.forward, out hit, _fireDist))
        {
            //	충돌 검출 OK !!!!!

            //	충돌한 오브젝트로부터
            //	IDamageable 참조 시도..
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            //	충돌한 오브젝트가
            //	IDamageable 를 소유하고 있다면
            //	공격에 대한 데미지 처리를
            //	할 수 있는 오브젝트라는 의미..
            if (target != null)
            {
                //	데미지 적용하기..
                target.OnDamage(_damage, hit.point, hit.normal);
            }

            //	레이가 충돌한 위치 저장..
            hitPos = hit.point;

        }//	if( Physics.Raycast( _fireTransf.position, _fireTransf.forward, out hit, _fireDist ))
        else
        {
            //	충돌 검출 실패 ㅠㅠ..

            //	탄알의 최대 사정거리까지의
            //	위치를 충돌위치로 사용.
            hitPos = _fireTransf.position + _fireTransf.forward * _fireDist;

        }//	~if( Physics.Raycast( _fireTransf.position, _fireTransf.forward, out hit, _fireDist ))

        //	발사 이펙트 재생..
        StartCoroutine(ShotEffect(hitPos));

        //	남은 탄알 수 차감..
        --_magAmmo;

        //	탄알이 없다면
        //	총의 상태를 Empty로 갱신..
        if (_magAmmo <= 0)
            _eCurState = eSTATE.Empty;
    }

    IEnumerator ShotEffect(Vector3 hitPos)
    {
        _muzzleFlashEffect.Play();
        //_shellEjectEffect.Play();
        _gunAudioPlayer.PlayOneShot(_shotClip);

        //	라인 렌더러 시작 지점 설정..
        _bulletLineRenderer.SetPosition(0, _fireTransf.position);

        //	라인 렌더러 마지막 지점 설정..
        _bulletLineRenderer.SetPosition(1, hitPos);

        //	라인 렌더러를 활성화하여 탄알 궤적 그리기..
        _bulletLineRenderer.enabled = true;

        //	0.03초 대기..
        yield return new WaitForSeconds(0.03f);

        //	라인 렌더러를 비활성화하여 탄알 궤적 지우기..
        _bulletLineRenderer.enabled = false;
    }
    public virtual bool Reload()
    {
        //	재장전 중이거나
        //	남은 탄알 없거나
        //	탄창에 탄알이 가득한 경우..
        if (_eCurState == eSTATE.Reloading ||
            _ammoRemain <= 0 ||
            _magAmmo >= _magCapacity)
            return false;

        //	재장전 진행..
        StartCoroutine(ReloadRoutine());
        return true;
    }
    protected virtual IEnumerator ReloadRoutine()
    {
        //	현재 상태를 [ 재장전 중 ] 상태로 전환..
        _eCurState = eSTATE.Reloading;

        //	재장전 소리 연출..
        _gunAudioPlayer.PlayOneShot(_reloadClip);

        //	재장전 소요 시간만큼 대기..
        yield return new WaitForSeconds(_reloadTime);

        //	탄창에 채울 탄알수 계산..
        int ammoToFill = _magCapacity - _magAmmo;

        //	탄창에 채워야할 탄알수가
        //	남은 탄알 수보다 많다면
        //	남은 탄알수만 적용..
        if (_ammoRemain < ammoToFill)
            ammoToFill = _ammoRemain;

        //	탄창 채우기..
        _magAmmo += ammoToFill;

        //	남은 탄알수 갱신..
        _ammoRemain -= ammoToFill;

        //	현재 상태를 [ 발사 준비 ] 상태로 전환..
        _eCurState = eSTATE.Ready;
    }
}
