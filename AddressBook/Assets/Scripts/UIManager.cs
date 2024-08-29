using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _Inst;

    private void Awake()
    {
        _Inst = this;
    }

    [SerializeField] GameObject[] _uis;
    [SerializeField] Text _msg;
    [SerializeField] float _delay;

    Coroutine _cor;

    public enum UI
    {
        LOBBY,
        ADD,
        EDIT,

        MAX
    }

    public enum MESSAGE
    {
        SUCCESS,
        DUPLICATIONERROR,
        DUPLICATIONNULLERROR,
        NULLERROR,
        REMOVE,
        EDIT,
        NOTEDIT,
        FILELOADFAIL,

        MAX
    }

    public enum POPUP
    {
        DETAIL,
        REMOVE,
        EDIT,

        MAX
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

    public void Message(MESSAGE msg)
    {
        if (_cor != null)
            StopCoroutine(_cor);

        if (msg == MESSAGE.SUCCESS)
        {
            _cor = StartCoroutine(MessageEffect("등록이 완료되었습니다.", Color.black));
        }
        else if(msg == MESSAGE.DUPLICATIONERROR)
        {
            _cor = StartCoroutine(MessageEffect("중복된 이름입니다.", Color.red));
        }
        else if (msg == MESSAGE.DUPLICATIONNULLERROR)
        {
            _cor = StartCoroutine(MessageEffect("중복확인을 하지 않았습니다.", Color.red));
        }
        else if (msg == MESSAGE.NULLERROR)
        {
            _cor = StartCoroutine(MessageEffect("잘못된 정보가 존재합니다.", Color.red));
        }
        else if(msg == MESSAGE.REMOVE)
        {
            _cor = StartCoroutine(MessageEffect("삭제가 완료되었습니다.", Color.black));
        }
        else if(msg == MESSAGE.EDIT)
        {
            _cor = StartCoroutine(MessageEffect("편집이 완료되었습니다.", Color.black));
        }
        else if(msg == MESSAGE.NOTEDIT)
        {
            _cor = StartCoroutine(MessageEffect("편집할 데이터가 없습니다.", Color.red));
        }
        else if(msg == MESSAGE.FILELOADFAIL)
        {
            _cor = StartCoroutine(MessageEffect("파일로드에 실패하였습니다.", Color.red));
        }
    }

    IEnumerator MessageEffect(string text, Color color)
    {
        _msg.text = text;
        _msg.color = color;
        _msg.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delay);
        _msg.gameObject.SetActive(false);
    }
}
