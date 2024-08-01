using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{
    //-----------------------------------------------
    public float _startingHealth = 100f;        //	시작 체력..
    public float Health { get; protected set; } //	현재 체력..
    public bool IsDead { get; protected set; }  //	사망 상태 체크..
    public event Action OnDeath;                //	사망시 발동 이벤트..

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
        //	이미 죽은 상태에선
        //	체력 회복 무효..
        if (IsDead)
            return;

        Health += newHealth;
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (IsDead) return;

        //	체력 감소..
        Health -= damage;

        //	체력이 고갈 사망처리..
        if (Health <= 0f)
            Die();
    }
}
