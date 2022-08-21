using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour
{
    [SerializeField] private Transform _controlObject;
    [SerializeField] private Transform m_FollowTarget;
   
    [SerializeField] private float m_AngleRange = 100f;
    [SerializeField] private float _turnSpeed = 1;
    [SerializeField] private float m_DistanceRange = 100;

    private bool _isCanFollow = false;
    public void SetTarget(Transform target)
    {
        m_FollowTarget = target;
    }

    private void Update()
    {
        if (m_FollowTarget != null && _controlObject != null)
            Turn();
    }   

    private void Turn()
    {
        CanvasInfo.SetText(Vector3.Angle(transform.forward, _controlObject.forward).ToString());
        var localTarget = m_FollowTarget.position;
        localTarget.y = _controlObject.position.y;
        var direction = localTarget - _controlObject.position;
        _isCanFollow = CheckCanFollow(direction);
        if (_isCanFollow)
        {            
            var quat = Quaternion.LookRotation(direction);
            _controlObject.rotation = Quaternion.RotateTowards(_controlObject.rotation, quat, _turnSpeed);
        } 
    }

    public bool CanFollowCurrentTarget()
    {
        return _isCanFollow;
    }

    public bool CheckCanFollow(Vector3 direction)
    {       
        return Vector3.Angle(transform.right, direction) < m_AngleRange && direction.magnitude < m_DistanceRange;
    }


}
