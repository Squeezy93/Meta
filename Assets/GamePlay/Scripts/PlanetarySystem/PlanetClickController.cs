using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace GamePlay.PlanetarySystem
{
    public class PlanetClickController : MonoBehaviour
    {
        public event Action<PlanetData> OnButtonClickHandler = delegate { };
        [SerializeField] private Button m_Button; 
        private PlanetData _planetData;

        private void Awake()
        {    
            m_Button.onClick.AddListener(() => OnButtonClickHandler.Invoke(_planetData));
        }

        public void SetPlanetData(PlanetData planetData)
        {
            _planetData = planetData;
        }
        
    }
}
