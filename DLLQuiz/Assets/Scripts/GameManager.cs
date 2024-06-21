using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject _collect;
    [SerializeField] GameObject _choose;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _list.SetCurNodeBack();
            if (_list._IsValidCurNode == false)
                _list.SetCurNodeToStart();
            ShowCurNode();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _list.SetCurNodeNext();
            if (_list._IsValidCurNode == false)
                _list.SetCurNodeToEnd();
            ShowCurNode();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChooseNode();
        }
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

    public void ShowCurNode()
    {
        DLList.DoubleNode curNode = _list._CurNode;
        if(curNode == null)
        {
            return;
        }
        _collect.SetActive(true);
        _collect.transform.parent = curNode._data.transform;
        _collect.transform.localPosition = new Vector3(0, 1, 0);
    }
}
