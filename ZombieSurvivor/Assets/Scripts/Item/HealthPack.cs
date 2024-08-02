using UnityEngine;

public class HealthPack : MonoBehaviour,IItem
{
    public float _health = 50;

    public void Use(GameObject target)
    {
        Debug.Log("체력 증가 : " + _health);

		LivingEntity life = target.GetComponent<LivingEntity>();

		if( life != null )
			life.RestoreHealth(_health);

		Destroy(gameObject);

    }
}
