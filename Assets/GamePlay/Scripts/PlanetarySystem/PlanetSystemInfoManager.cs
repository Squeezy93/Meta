using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay.PlanetarySystem
{
    public class PlanetSystemInfoManager : MonoBehaviour
    {
        [SerializeField] private PlanetInfoView m_PlanetInfoView;
        [SerializeField] private Camera m_SystemCamera;
        [SerializeField] private FollowObjectOnCanvas m_ButtonHandlerPrefab;

        public void SetPlanets(PlanetController[] planetControllers)
        {
            foreach (var planetController in planetControllers)
            {
                var buttonHandler = Instantiate(m_ButtonHandlerPrefab, transform);
                buttonHandler.Camera = m_SystemCamera;
                buttonHandler.TargetFollow = planetController.PlanetObject;

                buttonHandler.OnButtonClickHandler += () =>
                {
                    OpenPlanetInfoView(planetController.PlanetData);
                };
            }

        }

        private void OpenPlanetInfoView(PlanetData planetData)
        {
            m_PlanetInfoView.OpenPlanetInfoView(planetData);
        }

    }
}
