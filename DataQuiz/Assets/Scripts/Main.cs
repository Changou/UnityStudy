using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [Header("메인")]
    [SerializeField] GameObject main;
    [SerializeField] InputField inputSearch;
    [SerializeField] Button searchBtn;

    [Header("추가록")]
    [SerializeField] Button addInBtn;
    [SerializeField] GameObject insert;
    [SerializeField] Button addBtn;

    AddressArray<Data> addArr; 

    // Start is called before the first frame update
    void Start()
    {
        addArr = new AddressArray<Data>(new Data("장호연", 26, "서울", "010-245")
            , new Data("홍길동", 35, "전국", "080-5465"), new Data("김첨지", 48, "어딘가", "010-9898"));
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
