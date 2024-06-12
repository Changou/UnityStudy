//=======================================================================
using UnityEngine;
using UnityEngine.UI;
//=======================================================================
public class VectorDotSample : MonoBehaviour
{
    //--------------------------------
    public Transform _pos1;
    public Transform _pos2;
    public Transform _center;
    public Text _text;
    //--------------------------------
    Color _color = Color.white;
    //--------------------------------
    void OnDrawGizmos()
    {
        CustomVector3 pos1 = new CustomVector3(_pos1.position);
        CustomVector3 pos2 = new CustomVector3(_pos2.position);
        CustomVector3 centerPos = new CustomVector3(_center.position);

        //  중점 -> 오브젝트로 향하는 방향벡터 계산..
        CustomVector3 centerToPos1 = pos1 - centerPos;
        CustomVector3 centerToPos2 = pos2 - centerPos;

        //  단위벡터로 변환..
        //  -   방향 값만 이용하기 위해..
        centerToPos1.Normalize();
        centerToPos2.Normalize();
        
        //  내적..
        float dot = CustomVector3.Dot (
            centerToPos1,
            centerToPos2 );
       
        //  같은 방향..     하얀색..
        if (dot == 1)
            _color = Color.white;
        //  180도..          검은색..
        else if (dot == -1)
            _color = Color.black;
        //  90도..           빨간색..
        else if (dot == 0)
            _color = Color.red;
        // 90 ~ 180도..      노란색..
        else if (dot < 0)
            _color = Color.yellow;
        // 0 ~ 90도..        파란색..
        else if (0 < dot && dot < 1)
            _color = Color.blue;

        Debug.DrawLine(centerPos.Trans, pos1.Trans, _color);
        Debug.DrawLine(centerPos.Trans, pos2.Trans, _color);

        //  각도..
        //  -   A * B = |A||B| cos@
        //  -   위에서 A와 B를
        //      단위 벡터로 계산 했으므로..
        //      -   cos@ = A * B
        //  -   코사인을 제거하기 위해
        //      역코사인을 양변에 적용..
        //      -   @ = arccos(A * B)
        //  -   @는 라디안 값이므로
        //      60분법으로 바꾸면..
        //      -   @ = arccos(A * B) * (180 / pi) 
        float ang = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //float ang = GetAngle360(centerToPos1, centerToPos2);

        _text.text = ang.ToString();

    }// void OnDrawGizmos()
    //--------------------------------
    //  0 ~ 360도로 표기..
    float GetAngle360(CustomVector3 startDir, CustomVector3 endDir)
    {
        float dot = CustomVector3.Dot( startDir, endDir );
        float ang = Mathf.Acos(dot) * Mathf.Rad2Deg;

        CustomVector3 cross = CustomVector3.Cross(startDir, endDir);
        if (cross._y < 0)
            ang = -ang + 360;

        return ang;

    }// float GetAngle360(Vector3 startDir, Vector3 endDir)
    //--------------------------------

}// public class VectorDotSample : MonoBehaviour
 //=======================================================================
/*  참고 : 
*          //  벡터 사이 각도..
*          https://blog.naver.com/happybaby56/221363538302
*  
*          //   내적 유도..
*          https://cynthis-programming-life.tistory.com/entry/%EB%B2%A1%ED%84%B0-%EB%82%B4%EC%A0%81-%EA%B3%B5%EC%8B%9D-%EC%9C%A0%EB%8F%84
*          
*          //  코사인 그래프..
*          https://www.calculat.org/kr/%EC%82%BC%EA%B0%81%ED%95%A8%EC%88%98/%EC%BD%94%EC%82%AC%EC%9D%B8.html
*/
//=======================================================================