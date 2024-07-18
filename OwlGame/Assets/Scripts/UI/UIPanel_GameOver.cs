using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanel_GameOver : UIPanelBase
{
    public void OnRetry()
    {
        //  현재 활성화된 씬 참조하기..
        Scene curScene = SceneManager.GetActiveScene();

        //  현재 씬 실행..
        SceneManager.LoadScene(curScene.name);

    }// public void OnRetry()
    //------------------------------
    //  게임 종료..
    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        Application.OpenURL("https://www.google.com/");
#else
        Application.Quit();
#endif
    }
}
