using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager i;

    [SerializeField] GameObject _ground;
    [SerializeField] GameObject _stageG2;
    [SerializeField] GameObject _stageG3;
    [SerializeField] int currentStage;
    [SerializeField] Text stageT;

    private void Awake()
    {
        i = this;
        _ground.SetActive(false);
        _stageG2.SetActive(false);
        _stageG3.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        StageSetting();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Next()
    {
        currentStage++;
        StageSetting();
    }

    void StageSetting()
    {
        stageT.text = "Stage" + currentStage;
        switch (currentStage)
        {
            case 1:
                _ground.SetActive(true);
                break;
            case 2:
                _ground.SetActive(false);
                _stageG2.SetActive(true);
                break;
            case 3:
                _stageG2.SetActive(false);
                _stageG3.SetActive(true);
                break;
        }
    }
    public int CurrentStage
    {
        get
        {
            return currentStage;
        }
    }
}
