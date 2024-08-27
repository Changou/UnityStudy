using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duplication : MonoBehaviour
{
    [SerializeField] Button _btn;
    [SerializeField] Text _success;
    [SerializeField] InputField _inputname;
    public bool _isCheck = false;

    private void OnEnable()
    {
        _isCheck = false;
        _btn.gameObject.SetActive(true);
        _success.gameObject.SetActive(false);
    }

    public void CheckDuplication()
    {

    }
}
