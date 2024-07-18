using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Input : UIPanelBase
{
    public enum eBTTNDIR
    {
        LEFT = -1,
        NONE,
        RIGHT
    }
    eBTTNDIR _ebttnDir = eBTTNDIR.NONE;

    public eBTTNDIR _eBttnDir => _ebttnDir;
    //---------------------------
    void Start()
    {
        _ebttnDir = eBTTNDIR.NONE;
    }
    //---------------------------
    public virtual void OnBttnPress(int bttnType)
    {
        switch (bttnType)
        {
            case 0:
                _ebttnDir = eBTTNDIR.LEFT;
                break;

            case 1:
                _ebttnDir = eBTTNDIR.RIGHT;
                break;

        }// switch( eBttnType )

    }// public void OnBttnPress( eBTTNDIR eBttnType )
    //---------------------------
    public virtual void OnBttnUp()
    {
        _ebttnDir = eBTTNDIR.NONE;
    }
}
