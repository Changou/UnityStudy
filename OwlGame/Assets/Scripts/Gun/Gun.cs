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
        if (GameManager_2._Inst._IsPause) return;
        
        if(_Shot)
            Shot();
    }

    void Shot()
    {
        GameObject bullet = Instantiate(_prefab);
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = Vector3.zero;
        bullet.transform.rotation = Quaternion.identity;
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        _Shot = false;
        yield return new WaitForSeconds(_ShotDelay);
        _Shot = true;
    }
}
