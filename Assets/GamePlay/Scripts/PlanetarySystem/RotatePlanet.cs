using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField] private Vector3 _angleSpeed;
    [SerializeField] private bool _rotate = false;

    private void Update()
    {
        if(_rotate)
            Rotate(Time.deltaTime);
    }

    public void SetAngleSpeed(Vector3 angleSpeed)
    {
        _angleSpeed = angleSpeed;
        _rotate = true;
    }

    private void Rotate(float deltaTime)
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + _angleSpeed* deltaTime);
    }
}
