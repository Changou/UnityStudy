using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DLList;

public class DLList
{ 
    public class DoubleNode
    {
        public GameObject _data;
        public DoubleNode _prev;
        public DoubleNode _next;

        public DoubleNode(GameObject data) : this(data, null, null) { }
        public DoubleNode(GameObject data, DoubleNode prev, DoubleNode next) 
        {
            _data = data;
            _prev = prev;
            _next = next;
        }

        public DoubleNode Append(GameObject val)
        {
            DoubleNode tmp = new DoubleNode(val, null, null);
            tmp._prev = this;
            tmp._next = _next;

            if(_next != null)
                _next._prev = tmp;

            _next = tmp;

            return tmp;
        }
        public void Remove()
        {
            if (_prev != null)
                _prev._next = _next;

            if(_next != null)
                _next._prev = _prev;
        }
    }
    DoubleNode _head;
    DoubleNode _tail;

    public DoubleNode _HeadNode => _head;
    public DoubleNode _TailNode => _tail;
    int _count = 0;
    public bool _isEmpty => _count == 0;
    DoubleNode _currentNode;
    public DoubleNode _CurNode => _currentNode;
    public GameObject _CurData => _CurNode._data;
    public void SetCurNodeNext() { _currentNode = _CurNode._next; }
    public void SetCurNodeBack() { _currentNode = _CurNode._prev; }
    public void SetCurNode(int idx) { _currentNode = GetNode(idx); }

    public void SetCurNodeToStart() { SetCurNode(0); }
    public void SetCurNodeToEnd() { SetCurNode(_Count - 1); }

    public bool IsValidCurNode() { return _CurNode != null; }

    public DLList() { _head = null; _currentNode = null; _count = 0; }

    public DoubleNode GetNode(int findIdx)
    {
        if (_isEmpty) return null;

        if (findIdx <= 0) return _head;

        if (findIdx >= _count - 1) return _tail;

        if (findIdx >= _count * 0.5f)
        {
            DoubleNode current = _tail;

            int idx = _count - 1;
            while (current != null)
            {
                if (idx == findIdx)
                    return current;

                current = current._prev;
                --idx;
            }
        }
        else
        {
            //  처음 노드부터 체크..
            DoubleNode current = _head;

            int idx = 0;
            while (current != null)
            {
                if (idx == findIdx)
                    return current;

                current = current._next;
                ++idx;

            }
        }
        return null;
    }

    public DoubleNode GetNode(string name)
    {
        if (_isEmpty) return null;

        DoubleNode current = _head;

        while (current != null)
        {
            if (current._data.GetComponent<Character>()._Name.Equals(name))
                return current;

            current = current._next;
        }
       
        return null;
    }

    public void Append(GameObject val)
    {
        if (_head == null)
        {
            DoubleNode newNode = new DoubleNode(val);
            _currentNode = newNode;
            _head = _currentNode;
            _tail = _currentNode;
            ++_count;
        }
        else
        {
            DoubleNode lastNode = _tail;
            if(lastNode != null)
            {
                _currentNode = lastNode.Append(val);
                _tail = _currentNode;
                ++_count;
            }
        }
    }

    public void Remove(int removeIdx)
    {
        if (_head == null ||
            removeIdx >= _Count)
            return;

        if (removeIdx == 0)
        {
            DoubleNode removeNode = _head;
            _head = _head._next;
            _currentNode = _head;
            removeNode.Remove();
            --_count;
        }
        else
        {
            DoubleNode removeNode = GetNode(removeIdx);
            _currentNode = removeNode._prev;
            if (removeNode == _tail)
                _tail = _currentNode;

            removeNode.Remove();
            --_count;
        }
    }
    public int _Count => _count;

}
