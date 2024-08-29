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
    [SerializeField] GameObject[] _popups;
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
        FILELOAD,
        SAVE,

        MAX
    }

    public enum POPUP
    {
        DETAIL,
        REMOVE,
        EDIT,
        SAVE,

        MAX
    }

    public void PopUp(POPUP pop, bool isOn)
    {
        _popups[(int)pop].SetActive(isOn);
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
            _cor = StartCoroutine(MessageEffect("����� �Ϸ�Ǿ����ϴ�.", Color.black));
        }
        else if(msg == MESSAGE.DUPLICATIONERROR)
        {
            _cor = StartCoroutine(MessageEffect("�ߺ��� �̸��Դϴ�.", Color.red));
        }
        else if (msg == MESSAGE.DUPLICATIONNULLERROR)
        {
            _cor = StartCoroutine(MessageEffect("�ߺ�Ȯ���� ���� �ʾҽ��ϴ�.", Color.red));
        }
        else if (msg == MESSAGE.NULLERROR)
        {
            _cor = StartCoroutine(MessageEffect("�߸��� ������ �����մϴ�.", Color.red));
        }
        else if(msg == MESSAGE.REMOVE)
        {
            _cor = StartCoroutine(MessageEffect("������ �Ϸ�Ǿ����ϴ�.", Color.black));
        }
        else if(msg == MESSAGE.EDIT)
        {
            _cor = StartCoroutine(MessageEffect("������ �Ϸ�Ǿ����ϴ�.", Color.black));
        }
        else if(msg == MESSAGE.NOTEDIT)
        {
            _cor = StartCoroutine(MessageEffect("������ �����Ͱ� �����ϴ�.", Color.red));
        }
        else if(msg == MESSAGE.FILELOADFAIL)
        {
            _cor = StartCoroutine(MessageEffect("���Ϸε忡 �����Ͽ����ϴ�.", Color.red));
        }
        else if(msg == MESSAGE.FILELOAD)
        {
            _cor = StartCoroutine(MessageEffect("���Ϸε忡 �����Ͽ����ϴ�.", Color.black));
        }
        else if(msg == MESSAGE.SAVE)
        {
            _cor = StartCoroutine(MessageEffect("���������� �Ϸ�Ǿ����ϴ�.", Color.black));
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
