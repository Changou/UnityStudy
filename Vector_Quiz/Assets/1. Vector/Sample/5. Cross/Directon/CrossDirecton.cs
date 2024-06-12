//========================================================================
using UnityEngine;
//========================================================================
public class CrossDirecton : MonoBehaviour
{
    //--------------------------------
    public Transform _pos1;
    public Transform _pos2;
    public Transform _center;
    public float _orbitSpeed = 3f;
    //--------------------------------
    //Vector3 _cross = Vector3.zero;
    CustomVector3 cross;
    //--------------------------------
    void OrbitRotate() 
    {
        CustomVector3 center = new CustomVector3(_center.position);
        CustomVector3 pos_up = new CustomVector3(transform.up);

        _pos1.RotateAround(center.Trans, pos_up.Trans, _orbitSpeed * Time.deltaTime); 
    }
    //--------------------------------
    private void OnDrawGizmos()
    {
        CustomVector3 pos1 = new CustomVector3(_pos1.position);
        CustomVector3 pos2 = new CustomVector3(_pos2.position);
        CustomVector3 center = new CustomVector3(_center.position);

        Debug.DrawLine(center.Trans, cross.Trans, Color.cyan);
        Debug.DrawLine(center.Trans, pos1.Trans, Color.white);
        Debug.DrawLine(center.Trans, pos2.Trans, Color.white);

        

        cross = CustomVector3.Cross(pos1, pos2);

        if (cross._y > 0)
            Debug.Log(_pos2.name + "은(는)" + _pos1.name + "의 오른쪽");
        else if (cross._y < 0)
            Debug.Log(_pos2.name + "은(는)" + _pos1.name + "의 왼쪽");
    }
    //--------------------------------
    void Update()
    {
        OrbitRotate();
    }
    //--------------------------------
}
//========================================================================
/*
 *  [ 참고 ]
 *  
 *      Unity 행성 공전&자전 구현하기 1편 (물체기준 회전)
 *      https://developer-mac.tistory.com/2
 *  
 *      [기하] 외적을 이용한 두 벡터의 상대적인 방향 판별
 *      https://bowbowbow.tistory.com/14
*/
//========================================================================
/*
    Quiz)
        [ 1. 벡터.txt ]에 설명한
        벡터의 특징을 참고하여
        벡터 구조체를 직접 만들어보고
        각각의 샘플등 이용하여
        정상적으로 작동하는지
        테스트 합니다..

 */
//========================================================================