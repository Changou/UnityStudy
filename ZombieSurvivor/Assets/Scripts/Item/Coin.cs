using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public int _score = 200;

    public void Use(GameObject target)
    {
        Debug.Log("점수 증가 : " + _score);

        /* 실제 처리.
		JGameManager.Instance.AddScore( _score );

		Destroy( gameObject );
		//*/
    }
}
