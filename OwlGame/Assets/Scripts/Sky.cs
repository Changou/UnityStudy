using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    Material _mat;

    public float _speed = 0.05f;

    private void Awake()
    {
        _mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ofs = _mat.mainTextureOffset;
        ofs.x += _speed * Time.deltaTime;

        _mat.mainTextureOffset = ofs;
    }
}
