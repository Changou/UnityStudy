using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjList : MonoBehaviour
{
    public CLList<GameObject>.CircleNode _FirstNode => _list.GetNode(0);

    //  마지막 노드 정보 얻기..
    public CLList<GameObject>.CircleNode _LastNode => _list.GetNode(_list._Count - 1);

    //  현재 노드 정보 얻기..
    public CLList<GameObject>.CircleNode _CurNode => _list._CurNode;

    //  인덱스를 이용한 노드 정보 얻기..
    public CLList<GameObject>.CircleNode GetNode(int idx) { return _list.GetNode(idx); }

    //  현재 노드를 다음노드로 이동..
    public void SetCurNodeToNext() { _list.SetCurNodeToNext(); }

    //  현재 노드가 유효한 노드인지 체크..
    public bool _IsValidCurNode { get { return _list._IsValidCurNode; } }
    //----------------------------------
    //  원형 연결 리스트..
    CLList<GameObject> _list = new CLList<GameObject>();
    public int _Count => _list._Count;

    public void Append(GameObject tmp)
    {
        _list.Append(tmp);
    }

    public void ShowInfo() { _list.ShowInfo(); }
}
