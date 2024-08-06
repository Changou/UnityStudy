using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG : Gun
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Rocket _rocket;

    protected override void Awake()
    {
        _gunAudioPlayer = GetComponent<AudioSource>();
    }

    protected override void Shot()
    {
        _rocket.enabled = true;
        

        --_magAmmo;

        if (_magAmmo <= 0)
            _eCurState = eSTATE.Empty;
    }

    public override bool Reload()
    {
        GameObject rocket = Instantiate(_prefab);
        rocket.transform.SetParent(transform);
        rocket.GetComponent<Rocket>().GetRPG();
        rocket.transform.localPosition = Vector3.zero;
        rocket.transform.localRotation = Quaternion.identity;
        _rocket = rocket.GetComponent<Rocket>();

        if (_eCurState == eSTATE.Reloading ||
            _ammoRemain <= 0 ||
            _magAmmo >= _magCapacity)
            return false;

        StartCoroutine(ReloadRoutine());
        return true;
    }
}
