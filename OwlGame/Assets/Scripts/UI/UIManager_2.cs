using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_2 : UIManager
{
    public float GetDir()
    {
        UIPanel_Input_2 tmp = _uiInput as UIPanel_Input_2;
        return tmp._BtnDir;
    }

    public void ResetDir()
    {
        UIPanel_Input_2 tmp = _uiInput as UIPanel_Input_2;
        tmp.ResetDir();
    }
}
