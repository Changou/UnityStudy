using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public struct CustomVector3
{
    public float _x;
    public float _y;
    public float _z;

    public CustomVector3(Vector3 tmp)
    {
        _x = tmp.x;
        _y = tmp.y;
        _z = tmp.z;
    }
    public CustomVector3(float x = 0, float y = 0, float z = 0)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public Vector3 Trans
    {
        get
        {
            Vector3 res = new Vector3(_x, _y, _z);
            return res;
        }
    }

    public static float SqrMagnitude(CustomVector3 v)
    {
        return v.Magnitude() * v.Magnitude();
    }

    public static float Dot(CustomVector3 v1, CustomVector3 v2)
    {
        return (v1._x * v2._x) + (v1._y * v2._y) + (v1._z * v2._z);
    }

    public static CustomVector3 Cross(CustomVector3 v1, CustomVector3 v2)
    {
        CustomVector3 res = new CustomVector3((v1._y * v2._z) - (v1._z * v2._y)
            , (v1._z * v2._x) - (v1._x * v2._z), (v1._x * v2._y) - (v1._y * v2._x));
        return res;
    }

    public static CustomVector3 operator -(CustomVector3 v1, CustomVector3 v2)
    {
        CustomVector3 res;
        res._x = v1._x - v2._x;
        res._y = v1._y - v2._y;
        res._z = v1._z - v2._z;
        return res; 
    }

    public static CustomVector3 operator *(CustomVector3 v1, float f)
    {
        CustomVector3 res;
        res._x = v1._x * f;
        res._y = v1._y * f;
        res._z = v1._z * f;
        return res;
    }

    public static float Distance(CustomVector3 cv1, CustomVector3 cv2)
    {
        return (cv2 - cv1).Magnitude();
    }

    
    public float Magnitude()
    {
        return Mathf.Sqrt((_x * _x) + (_y * _y) + (_z * _z));
    }

    public void Normalize()
    {
        float m = Magnitude();
        if (m > 0)
        {
            _x /= m;
            _y /= m;
            _z /= m;
        }
    }
    public CustomVector3 normalized
    {
        get
        {
            CustomVector3 res = this;
            res.Normalize();
            return res;
        }
    }
    
    public override string ToString()
    {
        return $"({_x}, {_y}, {_z})";
    }
}
