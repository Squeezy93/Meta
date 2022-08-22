using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour
{
    [SerializeField] private Transform _controlObject;
    [SerializeField] private Transform m_FollowTarget;
   
    [SerializeField] private float _angleRange = 100f;
    [SerializeField] private float _turnSpeed = 1;
    [SerializeField] private float _distanceRange = 20;
    [SerializeField] private float m_AimTreshold = 5;

    private bool _isCanFollow = false;
    private Quaternion _goalAngle;

    public bool _isLookAtTarget;
    public bool IsLookAtTarget => _isLookAtTarget;

    public void SetTarget(Transform target)
    {
        m_FollowTarget = target;
    }

    private void FixedUpdate()
    {
        _isLookAtTarget = false;
        if (m_FollowTarget != null && _controlObject != null)
        {
            CalculateAngle();
            Turn();
            _isLookAtTarget = Quaternion.Angle(_controlObject.rotation, _goalAngle) < m_AimTreshold && _isCanFollow;
        }
    }

    private void CalculateAngle()
    {       
        var localTarget = m_FollowTarget.position;
        localTarget.y = _controlObject.position.y;
        var direction = localTarget - _controlObject.position;      
        _isCanFollow = CheckCanFollow(direction) && m_FollowTarget != null && m_FollowTarget.gameObject.activeSelf;       
        _goalAngle = Quaternion.LookRotation(direction);        
    }

    private void Turn()
    {      
        if (_isCanFollow)
        {           
            _controlObject.rotation = Quaternion.RotateTowards(_controlObject.rotation, _goalAngle, _turnSpeed);            
        } 
    }

    public bool CanFollowCurrentTarget()
    {
        return _isCanFollow;
    }

    public bool CheckCanFollow(Vector3 direction)
    {       
        return Vector3.Angle(transform.right, direction) < _angleRange && direction.magnitude < _distanceRange;
    }


}
