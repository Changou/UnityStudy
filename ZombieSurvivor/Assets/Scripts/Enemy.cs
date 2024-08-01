using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : LivingEntity
{
    public LayerMask _targetLayerMask;  //  추적 대상 레이어..
    LivingEntity _targetEntity;      //  추적 대상..
    NavMeshAgent _pathFinder;        //  경로 이동 에이전트..
                                     //--------------------------------------
    public ParticleSystem _hitEffect;       //  피격 이펙트..
    public AudioClip _deathSound;    //  사망시 연출할 소리..
    public AudioClip _hitSound;      //  피격시 연출할 소리..
                                     //--------------------------------------
    Animator _animator;
    AudioSource _audioSource;
    Renderer _renderer;                 //	좀비의 외형 색을 설정하기위해 사용..
                                        //--------------------------------------
    public float _damage = 20f;         //	공격력..
    public float _attackTime = 0.5f;    //	공격 시간 간격..
    public float _lastAttackTime = 0f;	//	가장 최근 공격 시간..

    bool HasTarget
    {
        get
        {
            if (_targetEntity != null &&    //	추적할 대상이 존재 && 
                !_targetEntity.IsDead)     //	추적 대상이 살아있는가?
                return true;

            return false;

        }//	get
    }
    void Awake()
    {
        _pathFinder = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        //	Renderer 컴포넌트는
        //	자식 게임 오브젝트에 있으므로
        //	GetComponentInChildren 사용..
        _renderer = GetComponentInChildren<Renderer>();
    }
    public void Setup(
        float health,
        float damage,
        float speed,
        Color skinColor)
    {
        //	체력 설정..
        _startingHealth = health;
        Health = health;

        //	공격력 설정..
        _damage = damage;

        //	내비메시 에이전트의
        //	이동 속도 설정..
        _pathFinder.speed = speed;

        //	렌더러에 설정된
        //	첫번째 매터리얼의 색 설정..
        _renderer.material.color = skinColor;
    }

    IEnumerator UpdatePath()
    {
        while (!IsDead)
        {
            if (HasTarget)
            {
                _pathFinder.isStopped = false;

                //	추적 대상의 위치를 입력..
                _pathFinder.SetDestination(
                    _targetEntity.transform.position);
            }
            else
            {
                _pathFinder.isStopped = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, _targetLayerMask);

                for(int cur = 0; cur < colliders.Length; ++cur)
                {
                    LivingEntity entity = colliders[cur].GetComponent<LivingEntity>();

                    if(entity != null && !entity.IsDead)
                    {
                        _targetEntity = entity;
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
    private void Start()
    {
        StartCoroutine(UpdatePath());
    }
    private void Update()
    {
        _animator.SetBool("HasTarget", HasTarget);
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if(!IsDead)
        {
            _hitEffect.transform.position = hitPoint;

            _hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);
            _hitEffect.Play();

            _audioSource.PlayOneShot(_hitSound);
        }
        base.OnDamage(damage, hitPoint, hitNormal);
    }
    public override void Die()
    {
        base.Die();

        Collider[] myColliders = GetComponents<Collider>();
        foreach(Collider tmpColl in myColliders) 
            tmpColl.enabled = false;

        _pathFinder.enabled = false;

        _animator.SetTrigger("Die");

        _audioSource.PlayOneShot(_deathSound);
    }
    private void OnTriggerStay(Collider other)
    {
        if(!IsDead && Time.time >= _lastAttackTime + _attackTime)
        {
            LivingEntity attackTarget = other.GetComponent<LivingEntity>();

            if (attackTarget != null && attackTarget == _targetEntity)
            {
                _lastAttackTime = Time.time;

                Vector3 hitPoint = other.ClosestPoint(transform.position);

                Vector3 hitNormal = transform.position - other.transform.position;

                attackTarget.OnDamage(_damage, hitPoint, hitNormal);
            }
        }
    }
}
