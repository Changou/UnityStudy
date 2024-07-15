using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Clear : MonoBehaviour
{
    public void OnNext()
    {
        StageManager.i.NextStage();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
