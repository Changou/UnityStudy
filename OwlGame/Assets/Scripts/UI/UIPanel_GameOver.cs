using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanel_GameOver : UIPanelBase
{
    public void OnRetry()
    {
        //  ���� Ȱ��ȭ�� �� �����ϱ�..
        Scene curScene = SceneManager.GetActiveScene();

        //  ���� �� ����..
        SceneManager.LoadScene(curScene.name);

    }// public void OnRetry()
    //------------------------------
    //  ���� ����..
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
