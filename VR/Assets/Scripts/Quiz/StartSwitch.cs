using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSwitch : MonoBehaviour, IInteract
{
    public void Do_Interact(Transform target)
    {
        GameManager.Instance.GameStart();
        gameObject.SetActive(false);
    }
}
