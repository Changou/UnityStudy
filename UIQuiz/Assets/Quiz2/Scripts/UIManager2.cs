using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public static UIManager2 _Inst;

    private void Awake()
    {
        _Inst = this;
    }

    public enum UI
    {
        START,
        SELECT,
        GAME,
        RESULT,
        RANK,

        MAX
    }

    [SerializeField] GameObject[] _uis;

    // Start is called before the first frame update
    void Start()
    {
        Only_Show_UI(UI.START);
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

    public void Show_Rank()
    {
        _uis[(int)UI.RANK].SetActive(true);
    }
}
