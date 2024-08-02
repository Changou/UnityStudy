using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    [SerializeField] GameObject _uiSW;

    public void OnSelectWeapon()
    {
        gameObject.SetActive(false);
        _uiSW.SetActive(true);
    }
}
