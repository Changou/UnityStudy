using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StageText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _text.text = "Stage " + StageManager._Inst._Stage;
        StartCoroutine(Time());
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
