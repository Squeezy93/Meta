using GamePlay.SpaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.PlanetarySystem
{
    public class PlanetInfoView : MonoBehaviour
    {
        [SerializeField] private Text m_PlanetName;
        [SerializeField] private Text m_PlanetDescription;
        [SerializeField] private Text m_PlanetType;
        [SerializeField] private Text m_PlanetSize;
        [SerializeField] private Button m_CloseButton;
        [SerializeField] private Button m_CreateRoute;
        private PlanetData _planetData;

        private void Awake()
        {
            m_CloseButton.onClick.AddListener(() => gameObject.SetActive(false));
            m_CreateRoute.onClick.AddListener(CreateRoute);
        }

        public void OpenPlanetInfoView(PlanetData planetData)
        {
            _planetData = planetData;
            gameObject.SetActive(true);
            m_PlanetName.text = planetData.PlanetAngleMove.ToString();
            m_PlanetDescription.text = planetData.PlanetVectorPosition.ToString();
            m_PlanetSize.text = planetData.PlanetSize.ToString();
        }

        private void CreateRoute()
        {
            gameObject.SetActive(false);
            RouteSystem.CreateRoute(_planetData);
        }
    }
}

