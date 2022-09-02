using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.PlanetarySystem.Map
{
    public class PlanetSystemInfoManager : MonoBehaviour
    {
        [SerializeField] private PlanetInfoView m_PlanetInfoView;
        [SerializeField] private Camera m_SystemCamera;
        [SerializeField] private MapPlanetaryObject m_ButtonHandlerPrefab;
        [SerializeField] private Transform m_SpawnRoot;
        public void SetPlanets(PlanetController[] planetControllers)
        {
            foreach (var planetController in planetControllers)
            {
                var buttonHandler = Instantiate(m_ButtonHandlerPrefab, m_SpawnRoot);
                var mover = buttonHandler.GetComponent<FollowObjectOnCanvas>();
                mover.Camera = m_SystemCamera;
                mover.TargetFollow = planetController.PlanetObject;
                buttonHandler.SetPlanetData(planetController);
                buttonHandler.OnButtonClickHandler += OpenPlanetInfoView;
            }
        }

        private void OpenPlanetInfoView(PlanetData planetData)
        {
            m_PlanetInfoView.OpenPlanetInfoView(planetData);
        }

    }
}
