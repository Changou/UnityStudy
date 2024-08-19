using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _Inst;
    public enum UI
    {
        START,
        GAME,
        RESULT,
        END,

        MAX
    }

    private void Awake()
    {
        _Inst = this;
        Only_Show_UI(UI.START);
    }

    [SerializeField] GameObject[] _uis;
    [SerializeField] Text _gameCntText;

    private void Update()
    {
        UIupdate();
    }

    void UIupdate()
    {
        _gameCntText.text = "∞‘¿” : " + GameManager._Inst._gameCnt;
    }

    public void OffText()
    {
        _gameCntText.gameObject.SetActive(false);
    }

    public void Only_Show_UI(UI ui)
    {
        All_HideUI();
        _uis[(int)ui].SetActive(true);
    }

    void All_HideUI()
    {
        foreach (GameObject ui in _uis)
        {
            ui.SetActive(false);
        }
    }
}
