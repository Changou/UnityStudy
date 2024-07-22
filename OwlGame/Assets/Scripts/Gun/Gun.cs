using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _ShotDelay = 1f;

    bool _Shot = true;

    private void Update()
    {
        if (GameManager_2._Inst._IsPause || GameManager_2._Inst._IsGameOver) return;
        
        if(_Shot)
            Shot();
    }

    void Shot()
    {
        GameObject bullet = Instantiate(_prefab);
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = Vector3.up;
        bullet.transform.rotation = transform.rotation;
        bullet.transform.SetParent(null);
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        _Shot = false;
        yield return new WaitForSeconds(_ShotDelay);
        _Shot = true;
    }
}
