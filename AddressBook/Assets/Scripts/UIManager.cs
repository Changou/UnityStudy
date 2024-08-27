using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _Inst;
    [SerializeField] GameObject[] _uis;
    [SerializeField] Text _msg;
    [SerializeField] float _delay;

    Coroutine _cor;

    public enum UI
    {
        LOBBY,
        ADD,

        MAX
    }

    public enum MESSAGE
    {
        SUCCESS,
        DUPLICATIONERROR,
        NULLERROR,

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
            _cor = StartCoroutine(MessageEffect("����� �Ϸ�Ǿ����ϴ�.", Color.black));
        }
        else if (msg == MESSAGE.DUPLICATIONERROR)
        {
            _cor = StartCoroutine(MessageEffect("�ߺ�Ȯ���� ���� �ʾҽ��ϴ�.", Color.red));
        }
        else if (msg == MESSAGE.NULLERROR)
        {
            _cor = StartCoroutine(MessageEffect("�Է����� ���� ������ �����մϴ�.", Color.red));
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
