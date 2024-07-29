using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager _Inst;

    [Header("스테이지 정보")]
    [SerializeField] int _stage = 1;

    public int _Stage => _stage;

    public bool _IsStageClear = false;

    private void Awake()
    {
       
        var obj = FindObjectsOfType<StageManager>();
        if (obj.Length == 1)
        {
            _Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void StageClear()
    {
        _IsStageClear = true;
        _stage++;
        GameManagerS._Inst.GameOver();
    }
    public void Destroy()
    {
        Destroy(this);
        Destroy(gameObject);
    }
}
