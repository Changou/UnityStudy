using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select2 : MonoBehaviour
{
    [SerializeField] ToggleGroup _tg;
    [SerializeField] GameObject[] _cars;

    private void Awake()
    {
        GameManager2._Inst._GameResetEvent += () =>
        {
            foreach (GameObject car in _cars) 
            {
                car.transform.GetChild(3).gameObject.SetActive(false);
            }
        };
    }

    public void GameStart()
    {
        Toggle t = _tg.GetFirstActiveToggle();
        GameManager2._Inst._selectCar = (CAR_TYPE)(int.Parse(t.tag.ToString()) - 1);

        _cars[int.Parse(t.tag.ToString()) - 1].transform.GetChild(3).gameObject.SetActive(true);
        CinemachinCameraControll._Inst.SetTargetCamera(_cars[int.Parse(t.tag.ToString()) - 1].transform);

        UIManager2._Inst.Only_Show_UI(UIManager2.UI.GAME);
    }
}
