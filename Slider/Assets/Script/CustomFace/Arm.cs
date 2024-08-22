using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] protected Transform _body;
    [SerializeField] protected Transform[] _arms;
    protected Vector3 _prevScale;

    protected virtual void Start()
    {
        _prevScale = _body.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        BodyCheck();   
    }

    protected virtual void BodyCheck() 
    {
        if(_prevScale != _body.localScale)
        {
            float x = _body.localScale.x - _prevScale.x;

            Vector3 pos1 = _arms[0].localPosition;
            pos1.x -= x/2;
            _arms[0].localPosition = pos1;

            Vector3 pos2 = _arms[1].localPosition;
            pos2.x += x/2;
            _arms[1].localPosition = pos2;
        }
        _prevScale = _body.localScale;
    }
}
