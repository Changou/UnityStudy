using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CLList <T>
{
    public class CircleNode
    {
        public T _data;
        public CircleNode _next;

        public CircleNode(T data) : this(data, null) { }
        public CircleNode(T data, CircleNode next)
        {
            _data = data; _next = next;
        }
    }
    CircleNode _tail;          //  원형 연결리스트의 특성상
                                //  [ tail ]로 [ head ]를
                                //  참조 가능..

    CircleNode _curNode;       //  참조,삭제에 사용..
    public CircleNode _Tail => _tail;
    public CircleNode _CurNode => _curNode;
    public bool _IsValidCurNode { get { return _CurNode != null; } }
    int _count;
    //--------------------------------
    public void SetCurNodeToStart()
    {
        if (_tail != null)
            _curNode = _tail._next;
    }
    public void SetCurNodeToNext()
    {
        if (_tail != null)
            _curNode = _curNode._next;
    }
    public CLList()
    {
        _tail = null;
        _curNode = null;

        _count = 0;
    }
    public void Append(T data)
    {
        CircleNode newNode = new CircleNode(data);

        if (_IsEmpty)
        {
            //  처음 추가된 노드는
            //  머리이자 꼬리..
            _tail = newNode;
            newNode._next = _tail;

        }// if( _IsEmpty )
        else
        {
            //  머리는 tail의 next..
            newNode._next = _tail._next;
            _tail._next = newNode;
            _tail = newNode;    //  꼬리가 새로 생성된
                                //  노드를 가리킴..

        }// ~if( _head == null )

        _curNode = newNode;
        ++_count;

    }// public void Append( T data )
    //--------------------------------
    //  삽입..
    // public void Insert( int insertIdx, T val )
    //--------------------------------
    //  head 노드 얻기..
    public bool GetHead(out CircleNode headNode)
    {
        if (_IsEmpty)
        {
            headNode = null;
            return false;
        }

        _curNode = _tail._next; //  첫번째 노드..

        headNode = _curNode;

        return true;

    }// public bool GetHead( CCircleNode headNode )
    //--------------------------------
    public CircleNode GetNode(int idx)
    {
        if (_IsEmpty)
            return null;

        CircleNode curNode = null;

        if (_count == 1)
            return _tail;

        if (_tail != null)
        {
            curNode = _tail._next;

            //  인덱스가 노드의 범위를
            //  초과하면 순환..
            if (idx < 0)
                idx = _Count + (idx % _Count);
            else
                idx %= _Count;

            for (int i = 0; i < idx; ++i)
                curNode = curNode._next;

            return curNode;
        }

        return null;

    }// public CCircleNode GetNode( int idx )
    //--------------------------------
    public bool GetCurrent(out CircleNode curNode)
    {
        if (_IsEmpty)
        {
            curNode = null;
            return false;
        }

        curNode = _curNode;

        return true;

    }// public bool GetNext( out CCircleNode nextNode )
    //--------------------------------
    public void SetNextNode() { _curNode = _curNode._next; }
    //--------------------------------
    public void RemoveAll() { _tail = null; }
    public bool Remove(int idx)
    {
        if (_IsEmpty)
            return false;

        var removeNode = GetNode(idx);
        var preNode = GetNode(idx - 1);
        if (_tail == removeNode)
            _tail = preNode;
        preNode._next = removeNode._next;
        _curNode = preNode;
        --_count;

        if (_count == 0)
        {
            _tail = null;
            _curNode = null;
        }

        return true;

    }// public T Remove()
    //--------------------------------
    public bool _IsEmpty { get { if (_tail == null) return true; return false; } }
    //--------------------------------
    public int _Count { get { return _count; } }
    //--------------------------------
    //  전체 조회..
    public void ShowInfo()
    {
        if (_tail == null)
        {
            Debug.Log("Nothing to Show..");
            return;
        }

        var current = _tail._next;

        int cur = 0;
        string res = "";
        while (current != null && cur < _count)
        {
            if (cur != _count - 1)
                res += current._data + ", ";
            else
                res += current._data;

            current = current._next;
            ++cur;
        }

        Debug.Log(res);

    }
}
