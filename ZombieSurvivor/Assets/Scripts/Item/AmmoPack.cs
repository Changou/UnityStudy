using UnityEngine;

public class AmmoPack : MonoBehaviour, IItem
{
    public int _ammo = 30;

    public void Use(GameObject target)
    {
        Debug.Log("Åº¾Ë Áõ°¡ : " + _ammo);

		PlayerShooter player = target.GetComponent<PlayerShooter>();

		if( player != null && player._gun != null )
			player._gun._ammoRemain += _ammo;

		Destroy( gameObject );

    }
}
