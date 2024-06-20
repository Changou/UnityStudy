using System.Collections;
using System.Collections.Generic;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("¸®½ºÆ®")]
    [SerializeField] DLLObjList _list;

    [SerializeField] InputField _Removeinput;
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
        int idx = 0;
        while(idx < _list._Count)
        {
            DLList.DoubleNode tmp = _list.GetNode(idx);
            SetColor(tmp._data.GetComponentInChildren<Renderer>(), Color.white);
            ++idx;
        }
        if(curNode != null)
        {
            SetColor(curNode._data.GetComponent<Renderer>(), Color.red);
        }
    }

    public void SetColor( Renderer rnd, Color color) { rnd.material.color = color; }
}
