using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RulletObj : MonoBehaviour
{
    [Header("Á¡¼ö")]
    [SerializeField] float _point;

    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        switch (_point)
        {
            case 30:
                rend.material.color = Color.yellow;
                break;
            case 20:
                rend.material.color = Color.green;
                break;
            case 10:
                rend.material.color = Color.blue;
                break;
            case -30:
                rend.material.color = Color.black;
                break;
            case -20:
                rend.material.color = Color.gray;
                break;
            case -10:
                rend.material.color = Color.red;
                break;
            default:
                break;
        }
    }

    public float _Point
    {
        get { return _point; }
    }
}
