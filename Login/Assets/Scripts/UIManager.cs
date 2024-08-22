using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _Inst;

    [SerializeField] GameObject[] _uis;

    public enum UI
    {
        LOGIN,
        ACCESSION,
        ACCESSSUCCESS,
        SUCCESS,

        MAX
    }

    private void Awake()
    {
        _Inst = this;
    }

    public void Show_Only(UI ui)
    {
        AllHide();
        _uis[(int)ui].SetActive(true);
    }

    public void AllHide()
    {
        foreach(GameObject ui in _uis)
        {
            ui.SetActive(false);
        }
    }
}
