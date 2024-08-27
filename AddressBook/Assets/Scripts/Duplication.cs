using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duplication : MonoBehaviour
{
    [SerializeField] protected Button _btn;
    [SerializeField] protected Text _success;
    [SerializeField] protected InputField _inputName;
    public bool _isCheck = false;

    private void OnEnable()
    {
        _isCheck = false;
        _btn.gameObject.SetActive(true);
        _success.gameObject.SetActive(false);
    }

    public virtual void CheckDuplication()
    {
        if(_inputName.text.Equals(""))
        {
            UIManager._Inst.Message(UIManager.MESSAGE.NULLERROR);
            return;
        }
        if (!Central._Inst.CheckName(_inputName.text))
        {
            _btn.gameObject.SetActive(false);
            _success.gameObject.SetActive(true);
            _isCheck = true;
        }
        else
            UIManager._Inst.Message(UIManager.MESSAGE.DUPLICATIONERROR);
    }
}
