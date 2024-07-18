using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum ePANEL { INFO, INPUT, GAMEOVER }
    //------------------------
    [Header("[UI ÆÐ³Îµé]"), SerializeField]
    UIPanelBase[] _uiPanels;
    //------------------------
    UIPanel_Info _uiInfo;

    public void Set_Coin(int coin)
    {
        _uiInfo.Set_Coin(coin);
    }
    //-------------------------------
    public void Set_Height(float height)
    {
        _uiInfo.Set_Height(height);
    }
    //--------------------------------
    public void Set_Gift(int gift)
    {
        _uiInfo.Set_Gift(gift);
    }
    //--------------------------------
    public void Set_Bird(int bird)
    {
        _uiInfo.Set_Bird(bird);
    }
    //--------------------------------
    public void Set_Score(int score)
    {
        _uiInfo.Set_Score(score);
    }
    //------------------------
    protected UIPanel_Input _uiInput;
    public UIPanel_Input.eBTTNDIR _GetDir => _uiInput._eBttnDir;
    //------------------------
    void Awake()
    {

        HideAll();

        _uiInfo = _uiPanels[(int)ePANEL.INFO] as UIPanel_Info;
        _uiInput = _uiPanels[(int)ePANEL.INPUT] as UIPanel_Input;
    }
    //------------------------
    public void Show_Panel_Only(ePANEL eIdx)
    {
        HideAll();
        Show_Panel_With(eIdx);
    }
    //------------------------
    public void Show_Panel_With(ePANEL eIdx)
    {
        _uiPanels[(int)eIdx].Show(true);
    }
    //------------------------
    void HideAll()
    {
        foreach (UIPanelBase panel in _uiPanels)
            panel.Show(false);
    }
}
