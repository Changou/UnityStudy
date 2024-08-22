using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] Transform _body;

    Vector3 _prevScale;

    // Start is called before the first frame update
    void Start()
    {
        _prevScale = _body.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(_prevScale != _body.localScale)
        {
            float y = _body.localScale.y - _prevScale.y;

            Vector3 pos = _body.localPosition;
            pos.y -= (y / 2);
            _body.localPosition = pos;
        }
        _prevScale = _body.localScale;
    }
}
