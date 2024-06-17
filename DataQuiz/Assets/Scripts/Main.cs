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

    AddressArray<Data> addArr; 

    // Start is called before the first frame update
    void Start()
    {
        addArr = new AddressArray<Data>(new Data("��ȣ��", 26, "����", "010-245")
            , new Data("ȫ�浿", 35, "����", "080-5465"), new Data("��÷��", 48, "���", "010-9898"));
    }

    public void SearchInBtn()
    {

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
    }
}
