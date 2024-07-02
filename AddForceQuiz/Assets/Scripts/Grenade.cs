using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grenade : MonoBehaviour
{
    [SerializeField] float power = 100;

    Rigidbody rb;

    [SerializeField] GameObject prefab;
    [SerializeField] Slider powerSlider;

    // Start is called before the first frame update
    void Start()
    {
        powerSlider = GameObject.Find("PowerSlider").GetComponent<Slider>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    bool isDelay = true;
    bool isThrow = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isThrow)
        {
            if(isDelay)
            {
                ThrowPowerUp();   
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ThrowGrenade();
            isThrow = false;
            powerSlider.value = 100;
            StartCoroutine(DelayEx());
        }
    }
    IEnumerator DelayEx()
    {
        yield return new WaitForSeconds(1f);
        Explotion();
    }

    void Explotion()
    {
        GameObject explotion = Instantiate(prefab);
        explotion.transform.position = transform.localPosition;
        explotion.GetComponent<ParticleSystem>().Play();
        Destroy(explotion, 3f);
        Destroy(gameObject);
    }

    void ThrowGrenade()
    {
        rb.useGravity = true;
        transform.localRotation = Quaternion.Euler(-30, 0, 0); 
        rb.AddForce(transform.forward * power);
    }

    void ThrowPowerUp()
    {
        if (power < 1000)
        {
            power += 100 * Time.deltaTime;
            powerSlider.value = power;
        }
    }
}
