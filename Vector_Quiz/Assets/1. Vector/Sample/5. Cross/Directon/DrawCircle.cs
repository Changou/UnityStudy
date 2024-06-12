//============================================================================================
using UnityEngine;
//============================================================================================
[ RequireComponent(typeof(LineRenderer)) ]
//============================================================================================
public class DrawCircle : MonoBehaviour
{
    //-----------------------
    LineRenderer _lr;
    //-----------------------
    [Range(0, 100)]
    public int _segments = 50;
    [Range(0, 10)]
    public int _radX = 5;
    [Range(0, 10)]
    public int _radZ = 5;
    //-----------------------
    void DrawDebug()
    {
        float angle = 0f;
        Quaternion rot = Quaternion.LookRotation(transform.forward, transform.up);
        Vector3 lastPoint = Vector3.zero;
        Vector3 thisPoint = Vector3.zero;

        for (int i = 0; i < (_segments + 1); ++i)
        {
            thisPoint.x = Mathf.Sin(Mathf.Deg2Rad * angle) * _radX;
            thisPoint.z = Mathf.Cos(Mathf.Deg2Rad * angle) * _radZ;

            if (i > 0)
                Debug.DrawLine(rot * lastPoint + transform.position,
                                rot * thisPoint + transform.position,
                                Color.green, 0);

            lastPoint = thisPoint;
            angle += 360f / _segments;

        }// for (int i = 0; i < (_segments + 1); ++i)

    }// void DrawDebug()
    //-----------------------
    void OnDrawGizmos() { DrawDebug(); }
    //-----------------------
    void Draw()
    {
        float x, z;
        float angle = 0f;

        for (int i = 0; i < (_segments + 1); ++i)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * _radX * (1 / transform.localScale.x);
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * _radZ * (1 / transform.localScale.z);
            _lr.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / _segments);

        }// for (int i = 0; i < (_segments + 1); ++i)

    }// void Draw()
    //-----------------------
    void Start()
    {
        //*
        _lr = GetComponent<LineRenderer>();

        _lr.positionCount = _segments + 1;
        _lr.useWorldSpace = false;

        Draw();
        //*/
    }// void Start()
    //-----------------------

}// public class DrawCircle : MonoBehaviour
 //============================================================================================
 //  참고 : https://gamedev.stackexchange.com/questions/126427/draw-circle-around-gameobject-to-indicate-radius
 //         https://forum.unity.com/threads/solved-debug-drawline-circle-ellipse-and-rotate-locally-with-offset.331397/
 //============================================================================================