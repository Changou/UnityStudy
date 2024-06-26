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

        Debug.Log(removeNode.GetItem()._type + "+" + removeNode.GetItem()._value + "��(��) ����Ͽ����ϴ�.");
        Remove(removeNode);
        Setting();
        --_count;
    }

    void Remove(GObjNode removeNode)
    {
        if (_head == null || removeNode == null)
            return;

        //  ���� ������Ʈ ����..
        Destroy(removeNode._gobj.gameObject);

        //  �����Ϸ��� ��尡
        //  ù��° ������� üũ..
        if (removeNode == _head)
            _head = _head._next;
        else
        {
            GObjNode current = _head;

            //  ������ �����
            //  �ٷ� �� ��� Ž��..
            while (current._next != removeNode)
                current = current._next;

            //  ���� ����� next��
            //  ������ ����� next�� �����ϰ�
            //  ������ ��� ����..
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
