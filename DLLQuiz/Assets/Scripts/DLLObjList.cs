using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLLObjList : MonoBehaviour
{
    [SerializeField]
    Vector3 _startPos = Vector3.zero;
    //----------------------------------
    //  간격..
    [SerializeField]
    Vector3 _offset = new Vector3(2.5f, 0, 0);
    [SerializeField]
    Vector3 _rowOffset = new Vector3(0, -2.5f, 0);
    //----------------------------------
    //  원본 프리팹..
    [SerializeField]
    GameObject _prefabSrc;

    DLList _list = new DLList();

    public DLList _List => _list;
    public int _Count { get { return _List._Count; } }

    public DLList.DoubleNode _CurNode { get { return _list._CurNode; } }
    public DLList.DoubleNode GetNode(int idx) { return _list.GetNode(idx); }
   
    public bool _IsValidCurNode { get { return _list.IsValidCurNode(); } }
    public void SetCurNodeNext()
    {
        if (_IsValidCurNode)
            _list.SetCurNodeNext();
    }
    public void SetCurNodeBack()
    {
        if (_IsValidCurNode)
            _list.SetCurNodeBack();
    }
    public void SetCurNodeToStart() { _list.SetCurNodeToStart(); }
    public void SetCurNodeToEnd() { _list.SetCurNodeToEnd(); }

    public GameObject GetCurData() { return _list._CurData; }
    
    GameObject CreateGObj()
    {
        GameObject tmp = Instantiate(_prefabSrc);

        return tmp;
    }

    public void Remove(string name)
    {
        int removeIdx = GetNodeIndex(name);

        DLList.DoubleNode removeNode = _list.GetNode(removeIdx);

        if (removeNode != null)
        {
            Destroy(removeNode._data);

            _list.Remove(removeIdx);

            BuildPosition();

        }// if(removeNode != null)

    }

    int GetNodeIndex(string name)
    {
        int idx = 0;

        _list.SetCurNodeToStart();

        while (_list.IsValidCurNode())
        {
            Character tmp = _list._CurData.GetComponent<Character>();
            if (tmp._Name == name)
                return idx;

            _list.SetCurNodeNext();

            ++idx;

        }// while ( _list.IsValidCurNode() )

        //  못찾은 경우 에러 처리..
        return -1;

    }

    public void Append()
    {
        GameObject tmp = CreateGObj();
        _list.Append(tmp);
        BuildPosition();
    }

    void BuildPosition()
    {
        DLList.DoubleNode curNode = _list._HeadNode;
        curNode._data.transform.position = _startPos;
        curNode = curNode._next;
        int num = 1;

        while (curNode != null)
        {
            if (num % 5 == 0)
            {
                curNode._data.transform.position = new Vector3(0, curNode._prev._data.transform.position.y, 0) + _rowOffset;
            }
            else
                curNode._data.transform.position = curNode._prev._data.transform.position + _offset;
            curNode = curNode._next;
            ++num;
            
        }
    }
}
