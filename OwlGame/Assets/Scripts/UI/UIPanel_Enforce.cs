using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Enforce : UIPanelBase
{
    [Header("[ æ∆¿Ã≈€ ]")]
    [SerializeField] GameObject[] _Items;
    [SerializeField] int _SettingItemCnt = 3;
    [SerializeField] int _MaxLV = 5;

    List<GameObject> _itemL;

    private void OnEnable()
    {
        Set_Enforce();
    }

    public void Set_Enforce()
    {
        GameObject[] items = new GameObject[3];

        int cnt = 0;
        while(cnt < _SettingItemCnt) 
        {
            items[cnt] = _Items[Random.Range(0,_Items.Length)];
            if(cnt != 0)
            {
                if (items[cnt] == items[cnt -1] || items[cnt].GetComponent<ItemBase>()._LV >= _MaxLV)
                {
                    cnt--;
                }
            }
            cnt++;
            Debug.Log(cnt);
        }
        Setting(items);
    }
    void Setting(GameObject[] items)
    {
        foreach(GameObject item in items)
        {
            GameObject tmp = Instantiate(item);
            tmp.transform.SetParent(transform);
            tmp.SetActive(true);
            tmp.transform.localScale = Vector3.one;
            _itemL.Add(tmp);
        }
    }

    public void Destroy()
    {
        foreach(GameObject item in _itemL)
        {
            Destroy(item);
            _itemL.Remove(item);
        }
        transform.gameObject.SetActive(false);
    }
}
