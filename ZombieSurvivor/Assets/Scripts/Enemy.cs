using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : LivingEntity
{
    public LayerMask _targetLayerMask;  //  ���� ��� ���̾�..
    LivingEntity _targetEntity;      //  ���� ���..
    NavMeshAgent _pathFinder;        //  ��� �̵� ������Ʈ..
                                     //--------------------------------------
    public ParticleSystem _hitEffect;       //  �ǰ� ����Ʈ..
    public AudioClip _deathSound;    //  ����� ������ �Ҹ�..
    public AudioClip _hitSound;      //  �ǰݽ� ������ �Ҹ�..
                                     //--------------------------------------
    Animator _animator;
    AudioSource _audioSource;
    Renderer _renderer;                 //	������ ���� ���� �����ϱ����� ���..
                                        //--------------------------------------
    public float _damage = 20f;         //	���ݷ�..
    public float _attackTime = 0.5f;    //	���� �ð� ����..
    public float _lastAttackTime = 0f;	//	���� �ֱ� ���� �ð�..

    bool HasTarget
    {
        get
        {
            if (_targetEntity != null &&    //	������ ����� ���� && 
                !_targetEntity.IsDead)     //	���� ����� ����ִ°�?
                return true;

            return false;

        }//	get
    }
    void Awake()
    {
        _pathFinder = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        //	Renderer ������Ʈ��
        //	�ڽ� ���� ������Ʈ�� �����Ƿ�
        //	GetComponentInChildren ���..
        _renderer = GetComponentInChildren<Renderer>();
    }
    public void Setup(
        float health,
        float damage,
        float speed,
        Color skinColor)
    {
        //	ü�� ����..
        _startingHealth = health;
        Health = health;

        //	���ݷ� ����..
        _damage = damage;

        //	����޽� ������Ʈ��
        //	�̵� �ӵ� ����..
        _pathFinder.speed = speed;

        //	�������� ������
        //	ù��° ���͸����� �� ����..
        _renderer.material.color = skinColor;
    }

    IEnumerator UpdatePath()
    {
        while (!IsDead)
        {
            if (HasTarget)
            {
                _pathFinder.isStopped = false;

                //	���� ����� ��ġ�� �Է�..
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
