using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("[스테이지]"), SerializeField] int _Stage = 1;

    private void Awake()
    {
        var obj = FindObjectsOfType<Stage>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StageUp()
    {
        _Stage++;
    }

    public int _StageInfo
    {
        get { return _Stage;}
    }
}
