using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay.ShipSystem
{
    public class ShipMoveController : MonoBehaviour
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
            if (_desireLook != Vector3.zero)
            {
                var quat = Quaternion.LookRotation(_desireLook);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, _turnSpeed * deltaTime);
            }
        }

        private void Move(float deltaTime)
        {

            if (_desireMove.sqrMagnitude > Mathf.Epsilon)
            {
                _currentVelocity = Vector2.MoveTowards(_currentVelocity, _desireMove.normalized * _maxSpeed, _accelMove * deltaTime);
                if (_currentVelocity.magnitude > _maxSpeed)
                {
                    _currentVelocity = _currentVelocity.normalized * _maxSpeed;
                }
            }
            else
            {
                if (_currentVelocity.sqrMagnitude > Mathf.Epsilon)
                {
                    _currentVelocity = Vector2.MoveTowards(_currentVelocity, Vector2.zero, _accelStop * deltaTime);
                }
            }

            transform.position = transform.position + new Vector3(_currentVelocity.x, 0, _currentVelocity.y);
            
        }
    }
}