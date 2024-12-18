//==================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//==================================================================================
public class CrossBasic: MonoBehaviour
{
    //--------------------------------
    public Transform _pos1;
    public Transform _pos2;
    public Transform _center;
    //--------------------------------
    CustomVector3 _cross;
    //--------------------------------
    void OnDrawGizmos()
    {
        CustomVector3 pos1 = new CustomVector3(_pos1.position);
        CustomVector3 pos2 = new CustomVector3(_pos2.position);
        CustomVector3 centerPos = new CustomVector3(_center.position);

        CustomVector3 right = pos1 - centerPos;
        CustomVector3 forward = pos2 - centerPos;

        _cross = CustomVector3.Cross( forward.normalized, right.normalized );
        //_cross = Vector3.Cross( right.normalized, forward.normalized );
        _cross.Normalize();

        Vector3 cross = _cross.ToVector3();

        Debug.DrawLine(centerPos.ToVector3(), cross, Color.cyan);
        Debug.DrawLine(centerPos.ToVector3(), pos1.ToVector3(), Color.white);
        Debug.DrawLine(centerPos.ToVector3(), pos2.ToVector3(), Color.white);

    }// void OnDrawGizmos()
    //--------------------------------

}// public class VectorCrossSample2 : MonoBehaviour
 //==================================================================================