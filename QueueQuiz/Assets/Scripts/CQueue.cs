using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQueue<T>
{
    public class CQueueNode
    {
        //---------------
        public T _data;
        public CQueueNode _next;
        //---------------
        public CQueueNode(T data, CQueueNode next = null)
        {
            _data = data;
            _next = next;
        }
        //---------------

    }//	public class CQueueNode
     //--------------------------------
    CQueueNode _head;
    CQueueNode _tail;
    public CQueue() { _head = null; _tail = null; }
    public bool _IsEmpty
    {
        get
        {
            if (_head == null)
                return true;

            return false;
        }
    }
    int _count = 0;
    public int _Count => _count;
    //--------------------------------
    public void Enqueue(T data)
    {
        CQueueNode newNode = new CQueueNode(data);

        if (_tail == null)
            _head = newNode;
        else
            _tail._next = newNode;

        _tail = newNode;
        ++_count;

    }
    public T Dequeue()
    {
        if (_IsEmpty) throw new ApplicationException("Empty!!");

        CQueueNode retNode = _head;
        T retData = retNode._data;

        if (_head._next == null)
            Clear();
        else
            _head = retNode._next;

        --_count;
        return retData;

    }//	public T Dequeue()
     //--------------------------------
    public void Clear() { _head = _tail = null; _count = 0; }
    public void ShowInfo()
    {
        if (_IsEmpty)
        {
            Debug.Log("-- No Data --");
            return;
        }

        string res = "";
        CQueueNode curNode = _head;
        while (curNode != null)
        {
            if (curNode._next == null) res += curNode._data;
            else res += curNode._data + ",  ";

            curNode = curNode._next;

        }//	while(curNode != null)

        Debug.Log(res);

    }
}
