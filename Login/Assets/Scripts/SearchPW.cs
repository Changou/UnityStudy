using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPW : SearchID
{
    public override void SearchBtn()
    {
        string id = _inputName.text;
        string name = _inputAdress.text;

        string searchPw = Central._Inst.SearchPWInArchive(id, name);
        if (searchPw != null)
        {
            _search.transform.GetChild(0).GetComponent<Text>().text =
                $"귀하의 비밀번호는\n\"{searchPw}\" 입니다.";
            _search.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
            _search.transform.GetChild(1).gameObject.SetActive(true);

        StartCoroutine(Return());
    }
}
