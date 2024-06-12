//==============================================================================
using UnityEngine;
//==============================================================================
public class DirectionTest : MonoBehaviour
{
    //------------------------------------
    public GameObject _start;
    public GameObject _end;
    //------------------------------------
    void OnDrawGizmos()
    {
        Debug.DrawLine( _start.transform.position, _end.transform.position, Color.yellow );

        CustomVector3 pos1 = new CustomVector3(_start.transform.position);
        CustomVector3 pos2 = new CustomVector3(_end.transform.position);

        CustomVector3 dir = pos2 - pos1;

        dir.Normalize();

        Debug.Log(dir.ToString());

    }// void OnDrawGizmos()
    //------------------------------------

}// public class DirectionTest : MonoBehaviour
//==============================================================================
/*
 *  Quiz)   두개의 게임 오브젝트( A, B )를 생성합니다.
 *          마우스 왼쪽버튼을 클릭하면
 *          A에서 B로 향하는 총알이 발사되도록 합니다.
 *          총알은 RigidBody와
 *          프리팹등을 이용해서 구현합니다.
*/
//==============================================================================