using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("리스트")]
    [SerializeField] DLLObjList _list;

    [SerializeField] InputField _Removeinput;

    [Header("선택")]
    [SerializeField] GameObject _choose;

    [Header("삽입")]
    [SerializeField] InputField _InsertInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftShift();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightShift();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChooseNode();
        }
    }

    public void LeftShift()
    {
        _list.SetCurNodeBack();
        if (_list._IsValidCurNode == false)
            _list.SetCurNodeToStart();
        
        ShowCurNode();
    }

    public void RightShift()
    {
        _list.SetCurNodeNext();
        if (_list._IsValidCurNode == false)
            _list.SetCurNodeToEnd();
        ShowCurNode();
    }

    public void ChooseNode()
    {
        DLList.DoubleNode curNode = _list._CurNode;
        if (curNode == null)
        {
            return;
        }
        _choose.SetActive(true);
        _choose.transform.parent = curNode._data.transform;
        _choose.transform.localPosition = new Vector3(0, 2.7f, 1);
        Debug.Log(curNode._data.GetComponent<Character>().ToString());
    }

    public void OnRemove()
    {
        _list.Remove(_Removeinput.text);
        ShowCurNode();
    }

    public void OnAppend()
    {
        _list.Append();
        ShowCurNode();
    }

    public void OnInsert()
    {
        _list.Insert(int.Parse(_InsertInput.text));
        ShowCurNode();
    }

    public void ShowCurNode()
    {
        DLList.DoubleNode curNode = _list._CurNode;
        if(curNode == null)
        {
            return;
        }
        int idx = 0;
        while (idx < _list._Count)
        {
            DLList.DoubleNode tmp = _list.GetNode(idx);
            tmp._data.GetComponent<Animator>().SetBool("IsChoose", false);
            ++idx;
        }
        if (curNode != null)
            curNode._data.GetComponent<Animator>().SetBool("IsChoose", true);
    }
}
