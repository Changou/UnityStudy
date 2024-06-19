using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SSL;

public class SSL : MonoBehaviour
{
    public static SSL i;

    int _count = 0;

    public class GObjNode
    {
        public GameObject _gobj;
        public GObjNode _next;

        public GObjNode(GameObject prefab)
        {
            _gobj = prefab;
            _next = null;
        }
        
        public Item GetItem() { return _gobj.GetComponent<Item>(); }
    }
 
    GObjNode _head = null;

    void Awake()
    {
        i = this;
        _head = null;
        _count = 0;
    }

    GObjNode CreateNode(GameObject newPrefab)
    {
        GObjNode newNode = new GObjNode(newPrefab);
        return newNode;
    }
    public GObjNode GetNode(int idx)
    {
        var current = _head;
        for (int i = 0; i < idx && current != null; ++i)
            current = current._next;

        return current;

    }
    public void Remove(int idx)
    {
        GObjNode removeNode = GetNode(idx);
        if (removeNode == null)
            return;

        Debug.Log(removeNode.GetItem()._type + "+" + removeNode.GetItem()._value + "을(를) 사용하였습니다.");
        Remove(removeNode);
        Setting();
        --_count;
    }

    void Remove(GObjNode removeNode)
    {
        if (_head == null || removeNode == null)
            return;

        //  게임 오브젝트 제거..
        Destroy(removeNode._gobj.gameObject);

        //  제거하려는 노드가
        //  첫번째 노드인지 체크..
        if (removeNode == _head)
            _head = _head._next;
        else
        {
            GObjNode current = _head;

            //  삭제할 노드의
            //  바로 앞 노드 탐색..
            while (current._next != removeNode)
                current = current._next;

            //  이전 노드의 next에
            //  삭제할 노드의 next를 연결하고
            //  삭제할 노드 제거..
            if (current != null)
                current._next = removeNode._next;

        }
    }

    public void Add(GameObject newItem)
    {
        GObjNode newNode = CreateNode(newItem);

        if(_head == null)
        {
            _head = newNode;
        }
        else
        {
            GObjNode cur = _head;
            while(cur._next != null)
            {
                cur = cur._next;
            }
            cur._next = newNode;
        }
        ++_count;
        Setting();
    }
    


    public void ShowInfo()
    {
        var current = _head;

        string res = "";
        while(current != null)
        {
            if (current._next != null) res += current.GetItem()._type + ", ";
            else res += current.GetItem()._type;

            current = current._next;
        }
        Debug.Log(res);
    }
    public void Setting()
    {
        var current = _head;
        int num = 0;
        while (current != null)
        {
            if (num > 4)
            {
                current._gobj.transform.SetParent(GameObject.Find("Group").transform.GetChild(5));
                current._gobj.transform.localPosition = new Vector3(0, 0, 0);
            }
            else
            {
                current._gobj.transform.SetParent(GameObject.Find("Group").transform.GetChild(num));
                current._gobj.transform.localPosition = new Vector3(0, 0, 0);
            }
            num++;
            current = current._next;
        }
    }
}
