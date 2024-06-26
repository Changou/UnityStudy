using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjList : MonoBehaviour
{
    public CLList<GameObject>.CircleNode _FirstNode => _list.GetNode(0);

    //  ������ ��� ���� ���..
    public CLList<GameObject>.CircleNode _LastNode => _list.GetNode(_list._Count - 1);

    //  ���� ��� ���� ���..
    public CLList<GameObject>.CircleNode _CurNode => _list._CurNode;

    //  �ε����� �̿��� ��� ���� ���..
    public CLList<GameObject>.CircleNode GetNode(int idx) { return _list.GetNode(idx); }

    //  ���� ��带 �������� �̵�..
    public void SetCurNodeToNext() { _list.SetCurNodeToNext(); }

    //  ���� ��尡 ��ȿ�� ������� üũ..
    public bool _IsValidCurNode { get { return _list._IsValidCurNode; } }
    //----------------------------------
    //  ���� ���� ����Ʈ..
    CLList<GameObject> _list = new CLList<GameObject>();
    public int _Count => _list._Count;

    public void Append(GameObject tmp)
    {
        _list.Append(tmp);
    }

    public void ShowInfo() { _list.ShowInfo(); }
}
