using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectOnCanvas : MonoBehaviour
{
    public Transform TargetFollow;
    public Camera Camera;
    private Vector3 position;


    private void FixedUpdate()
    {
        if(TargetFollow)
        {
            position = Camera.WorldToScreenPoint(TargetFollow.position);
            transform.position = position;
        }
    }
}
