//===============================================================================================
using UnityEngine;
//===============================================================================================
public class CheckInSight : MonoBehaviour
{
    //-------------------------------------
    public float _viewAngle = 30;

    public float _radius = 5f;

    public Transform _target;
    //-------------------------------------
    void OnDrawGizmos()
    {
        CustomVector3 leftDir, rightDir;
        leftDir = GetVectorWithAngle(_viewAngle * 0.5f, _radius);
        rightDir = GetVectorWithAngle(-_viewAngle * 0.5f, _radius);
        
        CustomVector3 c_target = new CustomVector3(_target.position);
        CustomVector3 _mine = new CustomVector3(transform.position);

        Debug.DrawLine(_mine.Trans, _mine.Trans + leftDir.Trans, Color.green);
        Debug.DrawLine(_mine.Trans, _mine.Trans + rightDir.Trans, Color.green);

        if (IsTargetInSight(c_target, _radius)) Debug.Log("보인다!!!");
        else Debug.Log("어딨지???");

    }// void OnDrawGizmos()
    //-------------------------------------
    //  각도와 반지름으로 벡터 구하기..
    CustomVector3 GetVectorWithAngle(float angle, float radius)
    {
        CustomVector3 eulerC = new CustomVector3(transform.eulerAngles);
        float theta = angle - eulerC._y + 90;
        CustomVector3 dir = new CustomVector3(
            Mathf.Cos(theta * Mathf.Deg2Rad),
            0,
            Mathf.Sin(theta * Mathf.Deg2Rad))
            * radius;

        return dir;

    }// void GetVectorWithAngle(float angle, float radius, out Vector3 dir)
    //-------------------------------------
    bool IsTargetInSight(CustomVector3 target, float viewDist )
    {
        CustomVector3 _mine = new CustomVector3(transform.position);
        CustomVector3 _mine_forword = new CustomVector3(transform.forward);

        //  타겟의 방향 ..
        CustomVector3 targetDir = (target- _mine).normalized;
        float dot = CustomVector3.Dot(_mine_forword, targetDir);

        //  내적을 이용한 각 계산하기..
        //  -   theta = cos^-1( a dot b / |a||b|)
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //  거리 비교..
        //  -   Vector3.SqrMagnitude 는
        //      루트연산을 하지 않으므로 
        //      비교 거리를 제곱해줘야 함..
        float dist = CustomVector3.SqrMagnitude(_mine - target);
        if (viewDist * viewDist >= dist && theta <= _viewAngle * 0.5f)
            return true;

        return false;

    }// bool IsTargetInSight( Transform target, float viewDist )
    //-------------------------------------

}// public class DrawLineWithAngle : MonoBehaviour
 //===============================================================================================//
/*
    [ 참고 ]
        
        https://backback.tistory.com/435

        https://dallcom-forever2620.tistory.com/47

        https://m.blog.naver.com/nagne2011/221901826377
*/
//===============================================================================================//
/*
*  Quiz )
*      -    필드에 플레이어와
*           다수의 적들을 설치합니다..
*           
*      -    적들은 랜덤위치로 순찰을 하다가
*           플레이어가 시야에 걸리면
*           추적을 합니다.
*           
*      -    추적을 하다가 간격이
*           일정거리 안으로 좁혀지면
*           플레이어를 향해
*           총알을 발사합니다.
*           
*      -    간격이 벌어지면 다시 순찰
*           또는 추적을 진행합니다.
*           
*      -    필드에 벗어나지 않도록
*           이동처리 합니다.
*/
//===============================================================================================//