using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
                _instance = FindObjectOfType<UIManager>();

            return _instance;
        }
    }
    public Text _ammoText;          //	ź�� ǥ��.
    public Text _scoreText;         //	���� ǥ��.
    public Text _stageText;         //  �� �������� ǥ��
    public Text _waveText;          //	���̺� ǥ��.
    public GameObject _gameoverUI;  //	���� ���� �� ��µ� UI.
    public GameObject _stageClearUI; // �������� Ŭ���� �� ��µ� UI;

    //	ź�� ����.
    public void UpdateAmmoText(int magAmmo, int remainAmmo)
    { _ammoText.text = magAmmo + " / " + remainAmmo; }

    //	���� ����.
    public void UpdateScoreText(int newScore)
    { _scoreText.text = "Score : " + newScore; }

    public void UpdateStageText(int curStage)
    {
        _stageText.text = "Stage : " + curStage;
    }

    //	���̺� ����.
    public void UpdateWaveText(int waves, int enemyLeftCount)
    { _waveText.text = "Wave : " + waves + "\nEnemy Left : " + enemyLeftCount; }

    //	���� ���� UI Ȱ��ȭ.
    public void SetActiveGameoverUI(bool isActive)
    { _gameoverUI.SetActive(isActive); }

    public void SetActiveStageClearUI(bool isActive)
    { _stageClearUI.SetActive(isActive); }

    private void Awake()
    {
        //	�̹� ���� �Ŵ����� �����Ѵٸ�
        //	������ �ı�..
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        SetActiveGameoverUI(false);
        
    }
    private void Start()
    {
        UpdateStageText(StageManager._Inst._CurrentStage);
    }
}
