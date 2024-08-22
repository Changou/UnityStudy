using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] InputField _idInput;
    [SerializeField] InputField _passwordInput;
    [SerializeField] GameObject _errorMsg;
    [SerializeField] float _errorDelay;
    [SerializeField] Text _succesT;

    public void LoginBtn()
    {
        string id = _idInput.text;
        string password = _passwordInput.text;

        string name = Central._Inst.LoginArchive(id, password);
        if (name != null)
        {
            _succesT.text = name + "님\n환영합니다.";
            UIManager._Inst.Show_Only(UIManager.UI.SUCCESS);
        }
        else
        {
            StartCoroutine(Error());
        }
    }

    IEnumerator Error()
    {
        _errorMsg.SetActive(true);
        yield return new WaitForSeconds(_errorDelay);
        _errorMsg.SetActive(false);
    }
}
