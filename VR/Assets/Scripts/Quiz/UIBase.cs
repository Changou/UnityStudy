﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public void Show(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
}
