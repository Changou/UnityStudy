using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select2 : MonoBehaviour
{
    [SerializeField] ToggleGroup _tg;

    public void GameStart()
    {
        Toggle t = _tg.GetFirstActiveToggle();
        GameManager2._Inst._selectCar = (CAR_TYPE)(int.Parse(t.tag.ToString()) - 1);

        UIManager2._Inst.Only_Show_UI(UIManager2.UI.GAME);
    }
}
