using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remove : MonoBehaviour
{
    [SerializeField] AddressList _address;  

    public void RemoveAddress()
    {
        Central._Inst.CallRemoveAddress(_address.AddressNameValue);
        UIManager._Inst.Message(UIManager.MESSAGE.REMOVE);
        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
    }

    public void RemoveAllAddress()
    {
        Central._Inst.CallRemoveAllAddress();
        UIManager._Inst.Message(UIManager.MESSAGE.REMOVEALL);
        UIManager._Inst.Show_Only(UIManager.UI.LOBBY);
    }
}
