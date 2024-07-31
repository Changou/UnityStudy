using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //	전후 이동을 위한 입력 축( 버튼 )..
    public string _moveAxisName = "Vertical";

    //	좌우 회전을 위한 입력 축( 버튼 )..
    public string _rotateAxisName = "Horizontal";

    //	총 발사를 위한 입력 축( 버튼 )..
    public string _fireButtonName = "Fire1";

    //	재장전을 위한 입력 축( 버튼 )..
    public string _reloadButtonName = "Reload";
    public float Move { get; private set; }
    public float Rotate { get; private set; }
    public bool Fire { get; private set; }
    public bool Reload { get; private set; }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis(_moveAxisName);
        Rotate = Input.GetAxis(_rotateAxisName);
        Debug.Log("Move : "+ Move);
        Debug.Log("Rotate : " + Rotate);

        Fire = Input.GetButton(_fireButtonName);

        Reload = Input.GetButtonDown(_reloadButtonName);
    }
}
