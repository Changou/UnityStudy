using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block4 : MonoBehaviour
{
    [SerializeField] GameObject _block;
    [SerializeField] float _fadeRate = 0.2f;
    [SerializeField] float _time = 0;

    [SerializeField] Color _tmp;

    bool _fadeIn = true;

    private void Awake()
    {
        _tmp = _block.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
    }

    private void Update()
    {
        if (_time <= 0)
        {
            if (!_fadeIn)
            {
                _tmp.a -= _fadeRate * Time.deltaTime;
                _block.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = _tmp;
                Mathf.Clamp(_tmp.a, 0f, 1f);
                if(_tmp.a <= 0f)
                {
                    _block.GetComponent<BoxCollider>().enabled = false;
                    _time = 1f;
                    _fadeIn = true;
                }

            }
            else if (_fadeIn)
            {
                _tmp.a += _fadeRate * Time.deltaTime;
                _block.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = _tmp;
                Mathf.Clamp(_tmp.a, 0f, 1f);
                if(_tmp.a >= 1f)
                {
                    _block.GetComponent<BoxCollider>().enabled = true;
                    _time = 1f;
                    _fadeIn = false;
                }
            }
        }
        else
        {
            _time -= 1f * Time.deltaTime;
        }
    }
}
