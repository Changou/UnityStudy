using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum GAME
{
    바위,
    가위,
    보,

    MAX
}

public class Game : MonoBehaviour
{
    [SerializeField] public Sprite[] _sprites;
    [SerializeField] Image _cpuImg;
    [SerializeField] float _turnSpeed;

    public GAME _mySelect;

    private void OnEnable()
    {
        StartCoroutine(ChangeImg());
    }

    public void SetRock()
    {
        _mySelect = GAME.바위;
        Next();
    }
    public void SetScissor()
    {
        _mySelect = GAME.가위;
        Next();
    }
    public void SetPaper()
    {
        _mySelect = GAME.보;
        Next();
    }

    void Next()
    {
        UIManager._Inst.Only_Show_UI(UIManager.UI.RESULT);
    }
    IEnumerator ChangeImg()
    {
        int i = 0;
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(_turnSpeed);
            i = ++i >= _sprites.Length ? 0 : i;
            _cpuImg.sprite = _sprites[i];
            yield return null;
        }
    }
}
