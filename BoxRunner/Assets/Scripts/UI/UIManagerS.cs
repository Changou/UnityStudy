using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerS : MonoBehaviour
{
    //--------------------
    public enum eMENU
    {
        MAIN,
        RESULT,
        PAUSE,

        COUNT
    }
    [SerializeField]
    GameObject[] _uiList;
    //--------------------
    [Header("페이드 인 아웃"), SerializeField]
    FadeInOut _fadeInout;

    public void Show_Menu_Only(eMENU eIdx)
    {
        foreach (GameObject obj in _uiList)
            obj.SetActive(false);

        Show_Menu_With(eIdx);
    }
    //--------------------
    public void Show_Menu_With(eMENU eIdx)
    {
        _uiList[(int)eIdx].SetActive(true);
    }
    //--------------------
    public void Show_PauseUI()
    {
        Show_Menu_With(eMENU.PAUSE);
    }
    //--------------------
    public void Show_MainUI()
    {
        Show_Menu_Only(eMENU.MAIN);
    }
    //--------------------
    public void OnReplay()
    {
        Scene scene = SceneManager.GetActiveScene();
        StageManager._Inst._IsStageClear = false;
        _fadeInout.FadeOut(scene.name);
    }
    //---------------------
    public void OnFirstScene()
    {
        StageManager._Inst.Destroy();
        _fadeInout.FadeOut("Title");
    }
    //--------------------
    UI_Main _uiMain;
    public void SetText_RunDist_Main(float dist)
    {
        _uiMain.SetText_RunDist(dist);
    }
    public void SetText_Coin_Main(int coin)
    {
        _uiMain.SetText_Coin(coin);
    }
    //--------------------
    UI_ResultS _uiResult;
    public void SetText_RunDist_Result(float dist)
     {
        _uiResult.SetText_RunDist(dist);
    }
    public void SetText_Coin_Result(int coin)
    {
        _uiResult.SetText_Coin(coin);
    }
    //--------------------
    private void Awake()
    {
        Show_Menu_Only(eMENU.MAIN);
        
        _uiMain = _uiList[(int)eMENU.MAIN].GetComponent<UI_Main>();
        _uiResult = _uiList[(int)eMENU.RESULT].GetComponent<UI_ResultS>();
    }
}
