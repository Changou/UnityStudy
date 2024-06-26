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
        Debug.Log("== 위치 ===========");
        Debug.Log(_trs1.name + "의 위치 : " + _trs1.position);
        Debug.Log(_trs2.name + "의 위치 : " + _trs2.position);
         
    
        CustomVector3 pos1 = new CustomVector3(_trs1.position);
        CustomVector3 pos2 = new CustomVector3(_trs2.position);

        Debug.Log(
            "== " + _trs1.name + " & "
            + _trs2.name + " 변위 ===========");
        CustomVector3 offset = pos1 - pos2;
        Debug.Log(offset.ToString());

        Debug.Log(
            "== " + _trs1.name + " --> "
            + _trs2.name + " 방향 ===========");
        CustomVector3 dir = pos2 - pos1;
        Debug.Log(dir.ToString());

        Debug.DrawLine(
            pos1.ToVector3(),
            pos2.ToVector3());

        Debug.Log("== 정규화 된 방향 ===========");
        Debug.Log(dir.normalized.ToString());
    }

    
}
