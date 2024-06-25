using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStack<T>
{
    public class CStackNode
    {
        //-------------
        T _data;
        public T _Data => _data;
        CStackNode _next;
        public CStackNode _Next => _next;
        //-------------
        public CStackNode(T data, CStackNode next = null)
        {
            _data = data;
            _next = next;
        }
        //-------------
    }
    CStackNode _top;
    int _count = 0;
    public int _Count { get { return _count; } }
    //-------------------------
    public CStack() { _top = null; _count = 0; }
    public void Push(T data)
    {
        if (_top == null)
            _top = new CStackNode(data);
        else
        {
            var node = new CStackNode(data, _top);
            _top = node;
        }
        ++_count;
    }
    public bool _IsEmpty
    {
        get
        {
            if (_top == null)
                return true;

            return false;
        }

    }//	public bool _IsEmpty
     //-------------------------
    public T Pop()
    {
        if (_IsEmpty)
            throw new ApplicationException("Empty!!");

        T data = _top._Data;
        _top = _top._Next;
        --_count;
        return data;
    }

}
