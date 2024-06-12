//================================================================================
//  Vector3 커스터마이징..
//  [ 참고 :  https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Math/Vector3.cs
//            https://gist.github.com/dugurca/5528323
//            https://blog.naver.com/fear2002/221245587214
//  ]
//================================================================================
using UnityEngine;
//================================================================================
public struct SMyVector3
{
    //----------------------------------------
    public float _x;
    public float _y;
    public float _z;
    //----------------------------------------
    //  생성자..
    public SMyVector3(float xVal = 0, float yVal = 0, float zVal = 0)
    {
        _x = xVal;
        _y = yVal;
        _z = zVal;
    }
    public SMyVector3(Vector3 vec) : this(vec.x, vec.y, vec.z) { }
    public override string ToString()
    {
        string tmp = string.Format("_x : {0}   _y : {1}   _z : {2}", _x, _y, _z);
        return tmp;
    }
    //----------------------------------------
    //  사용자 정의 형변환..
    //  [참고: https://gist.github.com/dugurca/5528323 ]

    //  SMyVector3 -> Vector3 암시적 형변환..
    public static implicit operator Vector3(SMyVector3 mv) {
        return new Vector3(mv._x, mv._y, mv._z); }
    //  Vector3 -> SMyVector3 암시적 형변환..
    public static implicit operator SMyVector3(Vector3 v) {
        return new SMyVector3(v.x, v.y, v.z); }
    //----------------------------------------
    //  연산자 오버로딩..
    //  [ 참고 : https://ansohxxn.github.io/c%20sharp/operator/
    //           https://hijuworld.tistory.com/38 ]
    //  -   형식..
    //      [ public ] [ static ] 반환형 [ operator ] [ 연산자 ] ( 매개변수 )

    //  -   규칙..
    //      -   [ public ], [ static ] 키워드를 모두 포함..
    //      -   단항 연산자는 한 개의 매개변수, 이항 연산자는 두 개의 매개변수를 작성..

    //  +..
    public static SMyVector3 operator + (SMyVector3 mv1, SMyVector3 mv2) {
        return new SMyVector3(mv1._x + mv2._x, mv1._y + mv2._y, mv1._z + mv2._z); }
    public static SMyVector3 operator + (SMyVector3 mv1, float var) {
        return new SMyVector3(mv1._x + var, mv1._y + var, mv1._z + var); }
    
    //  -..
    public static SMyVector3 operator - (SMyVector3 mv1, SMyVector3 mv2) {
        return new SMyVector3(mv1._x - mv2._x, mv1._y - mv2._y, mv1._z - mv2._z); }
    public static SMyVector3 operator - (SMyVector3 mv1, float var) {
        return new SMyVector3(mv1._x - var, mv1._y - var, mv1._z - var); }
    
    //  *..
    public static SMyVector3 operator * (SMyVector3 mv1, SMyVector3 mv2) {
        return new SMyVector3(mv1._x * mv2._x, mv1._y * mv2._y, mv1._z * mv2._z); }
    public static SMyVector3 operator * (SMyVector3 mv, float var) {
        return new SMyVector3(mv._x * var, mv._y * var, mv._z * var); }    

    //  /..
    public static SMyVector3 operator / (SMyVector3 mv, float var) {
        return new SMyVector3(mv._x / var, mv._y / var, mv._z / var); }
    //----------------------------------------
    //  인덱서..
    public float this[int key]
    {
        get { return GetValueByIndex(key); }
        set { SetValueByIndex(key, value); }
    }
    void SetValueByIndex(int key, float value) {
        if (key == 0) _x = value;
        else if (key == 1) _y = value;
        else if (key == 2) _z = value;
    }
    float GetValueByIndex(int key)
    {
        if (key == 0) return _x;
        if (key == 1) return _y;
        return _z;
    }
    //----------------------------------------
    //  내적..
    public float Dot(SMyVector3 rVal) { return _x * rVal._x + _y * rVal._y + _z * rVal._z; }
    public static float Dot( SMyVector3 lVal, SMyVector3 rVal ) { return lVal.Dot(rVal); }

    /*  외적..
        [ 참고 : https://blog.naver.com/mindo1103/90103361104 ]
        -   앙페르의 오른손 법칙 적용..
            -   rVal -> lVal 방향으로  */
    public SMyVector3 Cross( SMyVector3 rVal )
    {
        SMyVector3 ret = new SMyVector3(
            _y * rVal._z - _z * rVal._y,
            _z * rVal._x - _x * rVal._z,
            _x * rVal._y - _y * rVal._x);

        return ret;
    }
    public static SMyVector3 Cross( SMyVector3 lVal, SMyVector3 rVal ) {
        return lVal.Cross(rVal); }
    //----------------------------------------
    //  크기..
    public float Magnitude() {
        return Mathf.Sqrt(_x * _x + _y * _y + _z * _z); }
    public static float Magnitude(SMyVector3 tmp) {
        return Mathf.Sqrt(tmp._x * tmp._x + tmp._y * tmp._y + tmp._z * tmp._z); }
    //  크기 제곱..
    public float SquareMagnitude() {
        return _x * _x + _y * _y + _z * _z; }
    //----------------------------------------
    //  정규화..
    //  -   현재 벡터의 값을 정규화..
    public void Normalize()
    {
        float m = Magnitude();
        if (m > 0)
        {
            _x = _x / m;
            _y = _y / m;
            _z = _z / m;

        }// if (m > 0)
        else
        {
            _x = 0;
            _y = 0;
            _z = 0;

        }// ~if (m > 0)

    }// public void Normalize()
    //----------------------------------------
    //  현재 벡터의 데이터 자체를 정규화 하지는 않고
    //  데이터를 이용하여 정규화된 벡터를 반환..
    public SMyVector3 _normalized
    {
        get
        {
            SMyVector3 result = this;
            result.Normalize();
            return result;

        }// get

    }// public SMyVector3 _normalized  
    //----------------------------------------
    //  방향..
    public SMyVector3 DirTo( SMyVector3 target ) {
        SMyVector3 start = this;
        return target - start; }
    public SMyVector3 UnitDirTo(SMyVector3 target)
    {
        SMyVector3 start = this;
        SMyVector3 dir = start.DirTo(target);
        return dir._normalized;
    }
    //----------------------------------------
    //  역벡터..
    public SMyVector3 Inverted() {
        return new SMyVector3(-_x, -_y, -_z); }    
    //  벡터간 거리..
    public static float Distance(SMyVector3 mv1, SMyVector3 mv2) {
        return (mv1 - mv2).Magnitude(); }
    //----------------------------------------
    //  기타..
    public static SMyVector3 up { get { return new SMyVector3(0f, 1f, 0f); } }
    public static SMyVector3 one { get { return new SMyVector3(1f, 1f, 1f); } }
    public static SMyVector3 zero { get { return new SMyVector3(0f, 0f, 0f); } }
    public static SMyVector3 RandomVector() { return new SMyVector3(Random.value, Random.value, Random.value); }

    //  위치벡터간의 방향..
    public static SMyVector3 GetDir( SMyVector3 start, SMyVector3 target ) {
        return start.DirTo(target); }
    public static SMyVector3 GetUnitDir(SMyVector3 start, SMyVector3 target) {
        return start.UnitDirTo(target); }
    //----------------------------------------
    
}// public class SMyVector3
//================================================================================