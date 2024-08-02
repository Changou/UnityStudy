using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    [SerializeField] GameObject _title;
    [SerializeField] GameObject _wGroup;

    [SerializeField] Animator _anim;

    private void Awake()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(1400, 0);
        _anim = GetComponent<Animator>();
        _title.SetActive(false);
        _wGroup.SetActive(false);
    }

    void OnEnable()
    {
        _anim.SetTrigger("Action");
    }

    public void OnSelect()
    {
        _title.SetActive(true);
        _wGroup.SetActive(true);
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(1400,700);
    }

    public void CollectWeapon(string type)
    {
        if (type.Equals("PISTOL"))
        {

        }
    }
}
