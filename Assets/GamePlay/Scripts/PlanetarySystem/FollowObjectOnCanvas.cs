using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.PlanetarySystem
{
    public class FollowObjectOnCanvas : MonoBehaviour
    {
        public event Action OnButtonClickHandler = delegate { };
        public Transform TargetFollow;
        public Camera Camera;
        [SerializeField] private Button m_Button;

        private void Awake()
        {
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(() => OnButtonClickHandler.Invoke());
        }

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
