using UnityEngine;

public class HealthPack : MonoBehaviour,IItem
{
    public float _health = 50;

    public void Use(GameObject target)
    {
        Debug.Log("체력 증가 : " + _health);

        /* 실제 처리.
		JLivingEntity life = target.GetComponent<JLivingEntity>();

		if( life != null )
			life.RestoreHealth(_health);

		Destroy(gameObject);
		*/
    }
}
