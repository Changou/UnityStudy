using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager _Inst;

    int _currentStage = 1;

    public int _CurrentStage => _currentStage;

    private void Awake()
    {
        if (_Inst != null)
            Destroy(gameObject);
        _Inst = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StageClear()
    {
        _currentStage++;
        GameManager.Instance.StageClear();
    }

}
