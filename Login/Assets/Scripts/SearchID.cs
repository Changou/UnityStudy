using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchID : MonoBehaviour
{
    [SerializeField] protected InputField _inputName;
    [SerializeField] protected InputField _inputAdress;
    [SerializeField] protected GameObject _search;
    [SerializeField] float _return;

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        for(int i = 0;i < _search.transform.childCount; i++)
        {
            _search.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public virtual void SearchBtn()
    {
        string name = _inputName.text;
        string adress = _inputAdress.text;

        string searchId = Central._Inst.SearchIDInArchive(name, adress);
        if (searchId != null)
        {
            _search.transform.GetChild(0).GetComponent<Text>().text =
                $"������ ���̵��\n\"{searchId}\" �Դϴ�.";
            _search.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
            _search.transform.GetChild(1).gameObject.SetActive(true);

        StartCoroutine(Return());
    }

    protected IEnumerator Return()
    {
        yield return new WaitForSeconds(_return);
        UIManager._Inst.Show_Only(UIManager.UI.LOGIN);
    }
}
