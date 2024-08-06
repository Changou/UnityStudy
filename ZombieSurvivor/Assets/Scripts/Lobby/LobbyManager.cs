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

    public void SelectPistol()
    {
        _type = GUN_TYPE.PISTOL;
    }
    public void SelectRifle()
    {
        _type = GUN_TYPE.RIFLE;
    }
    public void SelectRPG()
    {
        _type = GUN_TYPE.RPG;
    }
}
