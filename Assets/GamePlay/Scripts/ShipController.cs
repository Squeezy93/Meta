using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Vector3 _desireLook;
    private Vector2 _desireMove;
    private Vector2 _currentVelocity;
    [SerializeField] private float _maxSpeed = 1;
    [SerializeField] private float _accelMove = 0.2f;
    [SerializeField] private float _accelStop = 0.2f;
    [SerializeField] private float _turnSpeed = 1;

    public void SetMove(Vector2 move)
    {
        _desireMove = move;
        _desireMove.y = transform.position.y;  
    }

    public void SetDirection(Vector3 move)
    {
        _desireLook = move;
    }

    private void Update()
    {
        Move(Time.deltaTime);
        Turn(Time.deltaTime);
    }

    private void Turn(float deltaTime)
    {       
        var quat = Quaternion.LookRotation(_desireLook);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, _turnSpeed* deltaTime);

        Debug.DrawRay(transform.position, _desireLook);

    }

    private void Move(float deltaTime)
    {
      
        if (_desireMove.sqrMagnitude > Mathf.Epsilon)
        {
            _currentVelocity += _desireMove.normalized * _accelMove * deltaTime;
            if (_currentVelocity.magnitude > _maxSpeed)
            {
                _currentVelocity = _currentVelocity.normalized * _maxSpeed;
            }           
        }
        else
        {
            if (_currentVelocity.sqrMagnitude > Mathf.Epsilon)
            {
                _currentVelocity -= _currentVelocity * Vector2.one * _accelStop * deltaTime;
            }
        }

        transform.Translate(_currentVelocity.x,0, _currentVelocity.y);
        _desireMove = Vector2.zero;
    }
}
