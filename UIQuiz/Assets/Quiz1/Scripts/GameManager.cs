using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _Inst;

    public bool _IsgameOver = false;

    [Header("테스트용"), SerializeField] public bool _IsTestOn;

    private void Awake()
    {
        _Inst = this;
    }

    public int _gameCnt = 0;
    public int _winCnt = 0;
    public int _loseCnt = 0;
    public int _drawCnt = 0;
    
}
