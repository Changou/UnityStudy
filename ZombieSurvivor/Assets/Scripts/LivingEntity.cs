using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{
    //-----------------------------------------------
    public float _startingHealth = 100f;        //	���� ü��..
    public float Health { get; protected set; } //	���� ü��..
    public bool IsDead { get; protected set; }  //	��� ���� üũ..
    public event Action OnDeath;                //	����� �ߵ� �̺�Ʈ..

    protected virtual void OnEnable()
    {
        IsDead = false;

        Health = _startingHealth;
    }

    public virtual void Die()
    {
        if (OnDeath != null) OnDeath();

        IsDead = true;
    }
    public virtual void RestoreHealth(float newHealth)
    {
        //	�̹� ���� ���¿���
        //	ü�� ȸ�� ��ȿ..
        if (IsDead)
            return;

        Health += newHealth;
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (IsDead) return;

        //	ü�� ����..
        Health -= damage;

        //	ü���� �� ���ó��..
        if (Health <= 0f)
            Die();
    }
}
