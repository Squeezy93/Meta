using GamePlay.SpaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.ShipSystem
{
    public class AutoNavigator : MonoBehaviour
    {
        public bool ActiveAutoMove = false;
        [SerializeField] private ShipMoveController m_MoveController;
        private Transform _targetTransform;
       
        

        private void Awake()
        {
            RouteSystem.OnNewTarget += NewTargetHandler;
        }

        private void OnDestroy()
        {
            RouteSystem.OnNewTarget -= NewTargetHandler;
        }

        private void NewTargetHandler()
        {            
            _targetTransform = RouteSystem.TargetTransform;
            ActiveAutoMove = _targetTransform != null;
        }

        private void FixedUpdate()
        {
            if(ActiveAutoMove)
            {
                ControlRoute();
            }
        }

        private void ControlRoute()
        {
            var direction = _targetTransform.position - transform.position;
            m_MoveController.SetDirection(direction);
            m_MoveController.SetMove(new Vector3(direction.x, direction.z, 0));         
        }
    }
}
