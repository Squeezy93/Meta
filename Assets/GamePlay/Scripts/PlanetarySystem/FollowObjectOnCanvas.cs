using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.PlanetarySystem
{
    public class FollowObjectOnCanvas : MonoBehaviour
    {
        
        public Transform TargetFollow;
        public Camera Camera; 

        private void FixedUpdate()
        {
            if (TargetFollow)
            {
                var position = Camera.WorldToScreenPoint(TargetFollow.position);
                transform.position = position;
            }
        }
    }
}
