using GamePlay.SpaceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;
namespace GamePlay.PlanetarySystem
{
    public class PlanetController : MonoBehaviour
    {
        public Transform PlanetObject => m_PlanetObject;
        [SerializeField] private Transform m_PlanetObject;
        [SerializeField] private RotatePlanet m_RotatePlanet;
        [SerializeField] private TriggerHandler m_TriggerHandler;
        [SerializeField] private InterfaceManager _interfaceManager;
        public PlanetData PlanetData => _planetData;    
        private PlanetData _planetData;

        public void SetData(PlanetData planetData)
        {
            _planetData = planetData;

            m_RotatePlanet.SetAngleSpeed(_planetData.PlanetAngleMove);
            m_PlanetObject.localPosition = Vector3.right * _planetData.PlanetVectorPosition.x + Vector3.forward * _planetData.PlanetVectorPosition.z;
            m_PlanetObject.localScale = Vector3.one * _planetData.PlanetSize;
        }

        private void Awake()
        {
            _interfaceManager = FindObjectOfType<InterfaceManager>();
            m_TriggerHandler.OnTriggerEnterEvent += HitPlanet;
        }

        private void HitPlanet(Collider other)
        {
            var landing = other.GetComponent<PlayerLandingController>();
            if(landing != null)
            {
                _interfaceManager.OpenView("Planet");
            }
        }
    }
}
