using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager i;

    [Header("[½ºÅ×ÀÌÁö]"), SerializeField] 
    Stage _Stage;

    [Header("[¸Ê]"), SerializeField] GameObject[] _map;

    public int _CurrentStage => _Stage._StageInfo;

    private void Awake()
    {
        i = this;
        _Stage = GameObject.Find("StageInfo").GetComponent<Stage>();
    }

    private void Start()
    {
        for (int i = 0; i < _map.Length; i++)
        {
            if (i + 1 == _CurrentStage) { _map[i].SetActive(true); }
            else { _map[i].SetActive(false); }
        }
    }

    public void NextStage()
    {
        _map[_CurrentStage - 1].SetActive(false);
        _Stage.StageUp();
        Debug.Log(_CurrentStage);
    }

    public void SetStage()
    {
        Debug.Log(_CurrentStage);
        _map[_CurrentStage - 1].SetActive(true);
    }
}
