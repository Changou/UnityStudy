using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager i;

    [SerializeField] Transform _ground;
    [SerializeField] int currentStage;
    [SerializeField] Text stageT;

    private void Awake()
    {
        i = this;
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
                _ground.localScale = new Vector3(1, 1, 1);
                break;
            case 2:
                _ground.localScale = new Vector3(3, 1, 3);
                break;
            case 3:
                _ground.localScale = new Vector3(4, 1, 4);
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
