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

    [Header("��ü����")]
    [SerializeField] GameObject allDelete;

    [Header("����")]
    [SerializeField] Text stateT;

    [Header("���")]
    [SerializeField] GameObject info;
    [SerializeField] GameObject preFabT;

    AddressArray addArr;

    Data currentSearchD;

    // Start is called before the first frame update
    void Start()
    {
        addArr = new AddressArray(new Data("��ȣ��", 26, "����", "010-2480-4303")
            , new Data("ȫ�浿", 35, "����", "080-5465-4568"), new Data("��÷��", 48, "���", "010-9898-7891"));

        main.SetActive(true);
        insert.SetActive(false);
        search.SetActive(false);
        edit.SetActive(false);
        search.transform.GetChild(0).GetComponent<Text>().text = "";
    }
    public void infoBtn()
    {
        main.SetActive(false);
        info.SetActive(true);
        for(int i = 0; i < addArr.Length(); i++)
        {
            GameObject infoT = Instantiate(preFabT);
            infoT.transform.SetParent(info.transform.GetChild(0).transform);
            infoT.GetComponent<Text>().text = addArr.GetData(i);
        }
        StartCoroutine(StateText("����� Ȱ��ȭ �Ǿ����ϴ�."));
    }

    public void allDeleteYes()
    {
        addArr.RemoveAll();
        allDelete.SetActive(false);
        StartCoroutine(StateText("��ü������ �Ϸ�Ǿ����ϴ�."));
    }

    public void allDeleteNo()
    {
        allDelete.SetActive(false);
    }

    public void allDeletePopup()
    {
        allDelete.SetActive(true);
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
        edit.transform.GetChild(0).GetComponentInChildren<Text>().text = currentSearchD._name;
        edit.transform.GetChild(1).GetComponentInChildren<Text>().text = currentSearchD._age.ToString();
        edit.transform.GetChild(2).GetComponentInChildren<Text>().text = currentSearchD._address;
        edit.transform.GetChild(3).GetComponentInChildren<Text>().text = currentSearchD._phone;
    }

    public void Edit()
    {
        string[] idx = new string[edit.transform.childCount - 1];
        for (int i = 0; i < edit.transform.childCount - 1; i++)
        {
            if (edit.transform.GetChild(i).GetComponent<InputField>().text == null)
                idx[i] = "";
            else
                idx[i] = edit.transform.GetChild(i).GetComponent<InputField>().text;
        }
        addArr.Edit(currentSearchD, new Data(idx[0] == "" ? currentSearchD._name : idx[0]
            , idx[1] == "" ? currentSearchD._age : int.Parse(idx[1])
            , idx[2] == "" ? currentSearchD._address : idx[2]
            , idx[3] == "" ? currentSearchD._phone : idx[3]));
        edit.SetActive(false);
        main.SetActive(true);
        StartCoroutine(StateText("������ �Ϸ�Ǿ����ϴ�."));
    }

    public void BackBtn()
    {
        if(search.activeSelf) search.SetActive(false);
        if(insert.activeSelf) insert.SetActive(false);
        if(info.activeSelf) info.SetActive(false);

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

        currentSearchD = addArr.Search(inputSearch.text);
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
        Debug.Log("1");
        string[] idx = new string[insert.transform.childCount-2];
        for (int i = 0; i < insert.transform.childCount-2; i++)
        {
            idx[i] = insert.transform.GetChild(i).GetComponent<InputField>().text;
        }
        addArr.Add(new Data(idx[0], int.Parse(idx[1]), idx[2], idx[3]));
        insert.SetActive(false);
        main.SetActive(true);
        StartCoroutine(StateText("�߰��� �Ϸ�Ǿ����ϴ�.")); 
    }
}
