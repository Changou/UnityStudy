using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _Rifle;
    [SerializeField] GameObject _Grenade;
    [SerializeField] Transform _GrenadeSpawn;
    [SerializeField] GameObject slider;

    GameObject grenade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _Rifle.SetActive(true);
            Destroy(grenade);
            slider.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _Rifle.SetActive(false);
            slider.SetActive(true);
            if (grenade == null)
            {
                grenade = Instantiate(_Grenade);
                grenade.transform.parent = _GrenadeSpawn;
                grenade.transform.localPosition = Vector3.zero;
                grenade.SetActive(true);
            }
        }
    }
}
