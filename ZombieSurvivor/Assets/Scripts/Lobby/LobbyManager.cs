using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager _Inst;

    public GUN_TYPE _type;

    private void Awake()
    {
        if (_Inst != null)
        {
            Destroy(gameObject);
        }
        _Inst = this;
        DontDestroyOnLoad(gameObject);
    }
}
