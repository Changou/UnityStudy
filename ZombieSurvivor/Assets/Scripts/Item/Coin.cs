using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public int _score = 200;

    public void Use(GameObject target)
    {
        Debug.Log("���� ���� : " + _score);

        /* ���� ó��.
		JGameManager.Instance.AddScore( _score );

		Destroy( gameObject );
		//*/
    }
}
