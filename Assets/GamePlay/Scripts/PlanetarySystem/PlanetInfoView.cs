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

        private void Awake()
        {
            m_CloseButton.onClick.AddListener(() => gameObject.SetActive(false));
        }

        public void OpenPlanetInfoView(PlanetData planetData)
        {
            gameObject.SetActive(true);
            m_PlanetName.text = planetData.PlanetAngleMove.ToString();
            m_PlanetDescription.text = planetData.PlanetVectorPosition.ToString();
            m_PlanetSize.text = planetData.PlanetSize.ToString();
        }
    }
}

