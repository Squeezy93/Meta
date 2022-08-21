using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class PlayerInputManager : MonoBehaviour
{

    private Vector2 _moveDirection;
    private Vector2 _lookDirection;

    private ShipController _playerTransform;

    private Camera _camera;

    private void Start()
    {
        _playerTransform = FindObjectOfType<ShipController>();
        _camera = Camera.main;
    }

    private void Update()
    {
        PCControl();

    }

    private void PCControl()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.y = Input.GetAxis("Vertical");

        _playerTransform.SetMove(_moveDirection);


        if (Input.GetMouseButton(0))
        {
            var cam_ray = _camera.ScreenPointToRay(Input.mousePosition);
            var _d = Mathf.Abs(Vector3.Dot((_playerTransform.transform.position), Vector3.up));
            float _a = (-_d - Vector3.Dot(_playerTransform.transform.up, cam_ray.origin)) / Vector3.Dot(_playerTransform.transform.up, cam_ray.direction);
            var point = cam_ray.origin + cam_ray.direction * _a;          
            _playerTransform.SetDirection(point - _playerTransform.transform.position);
           
        }
    }
}
