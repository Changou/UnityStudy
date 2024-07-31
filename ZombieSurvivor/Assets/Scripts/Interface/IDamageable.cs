using UnityEngine;

public interface IDamageable
{
    /*
     *  damage      :   데미지 크기..
     *  hitPoint    :   피격 위치..
     *  hitNormal   :   피격 표면의 방향..
     */
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}
