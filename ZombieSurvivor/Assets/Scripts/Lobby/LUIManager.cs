using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUIManager : MonoBehaviour
{
    [Header("·Îºñ UI")]
    [SerializeField] GameObject _titleUI;
    [SerializeField] GameObject _selectUI;

    [SerializeField] Animator _titleAnim;

    private void Awake()
    {
        _titleUI.SetActive(true);
        _selectUI.SetActive(false);
    }

    public void OnSelectWeaponUI()
    {
        _titleAnim.SetTrigger("Action");
    }
}
