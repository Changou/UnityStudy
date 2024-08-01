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
    public Text _ammoText;          //	탄알 표시.
    public Text _scoreText;         //	점수 표시.
    public Text _waveText;          //	웨이브 표시.
    public GameObject _gameoverUI;  //	게임 오버 시 출력될 UI.
    public Button _onRestart;       //  재시작 버튼 이벤트.

    //	탄알 갱신.
    public void UpdateAmmoText(int magAmmo, int remainAmmo)
    { _ammoText.text = magAmmo + " / " + remainAmmo; }

    //	점수 갱신.
    public void UpdateScoreText(int newScore)
    { _scoreText.text = "Score : " + newScore; }

    //	웨이브 갱신.
    public void UpdateWaveText(int waves, int enemyLeftCount)
    { _waveText.text = "Wave : " + waves + "\nEnemy Left : " + enemyLeftCount; }

    //	게임 오버 UI 활성화.
    public void SetActiveGameoverUI(bool isActive)
    { _gameoverUI.SetActive(isActive); }

    //	게임 재시작.
    public void GameRestart()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    private void Awake()
    {
        //	이미 게임 매니져가 존재한다면
        //	본인을 파괴..
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        SetActiveGameoverUI(false);
        _onRestart.onClick.AddListener(GameRestart);
    }
}
