using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float _speed = 60f;

    private void Update() { transform.Rotate(0f, _speed * Time.deltaTime, 0f); }
}
