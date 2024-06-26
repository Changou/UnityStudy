using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz2 : MonoBehaviour
{
    [SerializeField]
    GameObject _gobj1;

    [SerializeField]
    GameObject _gobj2;

    float GetDistance(GameObject gobj1, GameObject gobj2)
    {
        CustomVector3 pos1 = new CustomVector3(_gobj1.transform.position);
        CustomVector3 pos2 = new CustomVector3(_gobj2.transform.position);

        //  °Å¸®..
        float dist = CustomVector3.Distance(pos1, pos2);
        return dist;
    }
    //----------------------------
    private void OnDrawGizmos()
    {
        float dist = GetDistance(_gobj1, _gobj2);

        Debug.Log(dist);
    }
}
