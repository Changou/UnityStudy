using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    protected Animator _anim;
    //--------------------------
    protected virtual void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    //--------------------------
    protected virtual void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            _anim.SetFloat("velocity", -1f);

        if (Input.GetButtonDown("Fire2"))
            _anim.SetFloat("velocity", 1f);

    }
}
