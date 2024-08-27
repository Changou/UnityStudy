using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditDuplication : Duplication
{
    [SerializeField] Edit _edit;

    public override void CheckDuplication()
    {
        if (_inputName.text.Equals(""))
        {
            UIManager._Inst.Message(UIManager.MESSAGE.NULLERROR);
            return;
        }
        if (!Central._Inst.CheckName(_inputName.text) || _inputName.text.Equals(_edit._currentName))
        {
            _btn.gameObject.SetActive(false);
            _success.gameObject.SetActive(true);
            _isCheck = true;
        }
        else
            UIManager._Inst.Message(UIManager.MESSAGE.DUPLICATIONERROR);
    }
}
