using UnityEngine;

public interface IDamageable
{
    /*
     *  damage      :   ������ ũ��..
     *  hitPoint    :   �ǰ� ��ġ..
     *  hitNormal   :   �ǰ� ǥ���� ����..
     */
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}
