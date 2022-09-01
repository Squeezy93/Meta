using GamePlay.PlanetarySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.SpaceSystem
{
    public class RouteSystem : MonoBehaviour
    {
        public static event Action OnNewTarget = delegate { };
        private static RouteSystem _instance;
        [SerializeField] private PlaneterySystemManager m_PlaneterySystemManager;
        private PlanetController m_PlaneteryController;

        public static Transform TargetTransform => _instance.m_PlaneteryController.PlanetObject;

        private void Awake()
        {
            _instance = this;
        }

        public static void CreateRoute(PlanetData planetData)
        {
            _instance.m_PlaneteryController = _instance.m_PlaneterySystemManager.FindPlanet(planetData);
            OnNewTarget.Invoke();
        }

        public static void ResetRoute()
        {
            _instance.m_PlaneteryController = null;
            OnNewTarget.Invoke();
        }
    }
}