using UnityEngine;

public class AmmoPack : MonoBehaviour, IItem
{
    public int _ammo = 30;

    public void Use(GameObject target)
    {
        Debug.Log("ź�� ���� : " + _ammo);

        /* ���� ó��.
		JPlayerShooter player = target.GetComponent<JPlayerShooter>();

		if( player != null && player._gun != null )
			player._gun._ammoRemain += _ammo;

		Destroy( gameObject );
		//*/
    }
}