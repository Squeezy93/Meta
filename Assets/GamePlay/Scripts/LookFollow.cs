using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour
{
    [SerializeField] private Transform _controlObject;
    [SerializeField] private Transform m_FollowTarget;
   
    [SerializeField] private float m_AngleRange = 100f;
    [SerializeField] private float _turnSpeed = 1;
    private Vector3 _startRotation;

    private void Start()
    {
        _startRotation = _controlObject.forward;
    }

    void Update()
    {
        if (m_FollowTarget != null && _controlObject != null)
            Turn();
    }

    private void Turn()
    {
        
        var localTarget = transform.InverseTransformDirection(m_FollowTarget.position);

        localTarget.y = _controlObject.position.y;
        if (Vector3.Angle(_startRotation, localTarget) < m_AngleRange/2)
        {
            var quat = Quaternion.LookRotation(localTarget - _controlObject.position);
            _controlObject.rotation = Quaternion.RotateTowards(_controlObject.rotation, quat, _turnSpeed);

        } 
    }


}
