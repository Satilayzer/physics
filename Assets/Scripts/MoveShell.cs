using UnityEngine;

public class MoveShell : MonoBehaviour
{
    private float _speed;
    private float _ySpeed;
    private float _mass = 1;
    private float _force = 30;
    private float _drag = 1;
    private float _gravity = -9.8f;
    private float _gAccel;
    private float _acceleration;
    
    private void Start()
    {
        _acceleration = _force / _mass;
        _speed += _acceleration;
        _gAccel = _gravity / _mass;
    }
    
    private void LateUpdate()
    {
        _speed *= 1 - Time.deltaTime * _drag;
        transform.Translate(0, _gAccel * Time.deltaTime, _speed * Time.deltaTime);
    }
}
