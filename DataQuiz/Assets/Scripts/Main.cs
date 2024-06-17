using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [Header("����")]
    [SerializeField] GameObject main;
    [SerializeField] InputField inputSearch;
    [SerializeField] Button searchBtn;
    [SerializeField] Toggle searchTog;

    [Header("�߰���")]
    [SerializeField] Button addInBtn;
    [SerializeField] GameObject insert;
    [SerializeField] Button addBtn;

    [Header("�˻�")]
    [SerializeField] GameObject search;

    [Header("����")]
    [SerializeField] GameObject edit;

    [Header("����")]
    [SerializeField] GameObject delete;

    [Header("����")]
    [SerializeField] Text stateT;

    AddressArray addArr;

    Data currentSearchD;

    // Start is called before the first frame update
    void Start()
    {
        addArr = new AddressArray(new Data("��ȣ��", 26, "����", "010-245")
            , new Data("ȫ�浿", 35, "����", "080-5465"), new Data("��÷��", 48, "���", "010-9898"));

        main.SetActive(true);
        insert.SetActive(false);
        search.SetActive(false);
        edit.SetActive(false);
        search.transform.GetChild(0).GetComponent<Text>().text = "";
    }

    IEnumerator StateText(string state)
    {
        stateT.text = state;
        stateT.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        stateT.gameObject.SetActive(false);
    }

    public void DeleteYes()
    {
        delete.SetActive(false);
        addArr.Remove(currentSearchD);
        search.SetActive(false);
        main.SetActive(true);
        StartCoroutine(StateText("������ �Ϸ�Ǿ����ϴ�."));
    }

    public void DeleteNo()
    {
        delete.SetActive(false);
    }

    public void DeletePopup()
    {
        delete.SetActive(true);
    }

    public void EditInBtn()
    {
        search.SetActive(false);
        edit.SetActive(true);

    }

    public void Edit()
    {
        string[] idx = new string[edit.transform.childCount - 1];
        for (int i = 0; i < edit.transform.childCount - 1; i++)
        {
            idx[i] = edit.transform.GetChild(i).GetComponent<InputField>().text;
        }
        addArr.Edit(currentSearchD,new Data(idx[0], int.Parse(idx[1]), idx[2], idx[3]));
        edit.SetActive(false);
        main.SetActive(true);
        StartCoroutine(StateText("������ �Ϸ�Ǿ����ϴ�."));
    }

    public void BackSearchToMainBtn()
    {
        search.SetActive(false);
        main.SetActive(true);
    }

    public void SearchInBtn()
    {
        main.SetActive(false);
        search.SetActive(true);
        search.transform.GetChild(1).gameObject.SetActive(true);
        search.transform.GetChild(2).gameObject.SetActive(true);
        Search();
        StartCoroutine(StateText("�˻��� �Ϸ�Ǿ����ϴ�."));
    }

    void Search()
    {
        int idx;
        if (searchTog.isOn)
            idx = 0;
        else
            idx = 2;
        currentSearchD = addArr.Search(idx, inputSearch.text);
        if (currentSearchD._name == null)
        {
            search.transform.GetChild(0).GetComponent<Text>().text = "�ش� �˻���� �������� �ʽ��ϴ�.";
            search.transform.GetChild(1).gameObject.SetActive(false);
            search.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
            search.transform.GetChild(0).GetComponent<Text>().text = currentSearchD.ToString();
    }

    public void AddInBtnClick()
    {
        main.SetActive(false);
        insert.SetActive(true);
        
    }

    public void AddInfoBtnClick()
    {
        string[] idx = new string[insert.transform.childCount-1];
        for (int i = 0; i < insert.transform.childCount-1; i++)
        {
            idx[i] = insert.transform.GetChild(i).GetComponent<InputField>().text;
        }
        addArr.Add(new Data(idx[0], int.Parse(idx[1]), idx[2], idx[3]));
        addArr.ShowInfo();
        insert.SetActive(false);
        main.SetActive(true);
        StartCoroutine(StateText("�߰��� �Ϸ�Ǿ����ϴ�.")); 
    }
}
