using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel_EffectTime : UIPanelBase
{
    [Header("[ 시간표시 ]")]
    [SerializeField] GameObject _prefab;

    public List<GameObject> _timerL;

    private void Awake()
    {
        _timerL = new List<GameObject>();
    }

    public void SetEffectTime(Sprite img, float time, ITEM_TYPE _type)
    {
        for(int i = 0;i< _timerL.Count;i++)
        {
            if(_timerL[i].transform.GetComponent<Image>().sprite == img ) 
            {
                Destroy(_timerL[i]);
                _timerL.RemoveAt(i);
                break;
            }
        }
        GameObject tmp = Instantiate(_prefab);
        tmp.transform.SetParent(transform);
        tmp.transform.localScale = Vector3.one;
        tmp.GetComponent<EffectTime>().Setting(img, time, _type);
        _timerL.Add(tmp);
    }

    public void Remove(GameObject obj)
    {
        _timerL.Remove(obj);
    }
}
