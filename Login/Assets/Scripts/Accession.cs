using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accession : MonoBehaviour
{
    [Header("회원가입")]
    [SerializeField] InputField[] _inputField;
    [SerializeField] float _delay;

    public void AccessBtn()
    {
        string[] _info = new string[_inputField.Length];

        for (int i = 0; i < _inputField.Length; i++)
        {
            _info[i] = _inputField[i].text;
        }

        Central._Inst.ArchiveAccession(_info);
        StartCoroutine(Success());
    }

    IEnumerator Success()
    {
        UIManager._Inst.Show_Only(UIManager.UI.ACCESSSUCCESS);
        yield return new WaitForSeconds(_delay);
        UIManager._Inst.Show_Only(UIManager.UI.LOGIN);
    }
}
