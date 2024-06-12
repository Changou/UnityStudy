using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Vector1 : MonoBehaviour
{
    public Transform _trs1 ;
    public Transform _trs2;

    private void OnDrawGizmos()
    {
        UpdateInfo();
    }

    void UpdateInfo()
    {
        Debug.Log("== ��ġ ===========");
        Debug.Log(_trs1.name + "�� ��ġ : " + _trs1.position);
        Debug.Log(_trs2.name + "�� ��ġ : " + _trs2.position);
         
    
        CustomVector3 pos1 = new CustomVector3(_trs1.position);
        CustomVector3 pos2 = new CustomVector3(_trs2.position);

        Debug.Log(
            "== " + _trs1.name + " & "
            + _trs2.name + " ���� ===========");
        CustomVector3 offset = pos1 - pos2;
        Debug.Log(offset.ToString());

        Debug.Log(
            "== " + _trs1.name + " --> "
            + _trs2.name + " ���� ===========");
        CustomVector3 dir = pos2 - pos1;
        Debug.Log(dir.ToString());

        Debug.DrawLine(
            _trs1.transform.position,
            _trs2.transform.position);

        Debug.Log("== ����ȭ �� ���� ===========");
        Debug.Log(dir.normalized.ToString());
    }

    
}
