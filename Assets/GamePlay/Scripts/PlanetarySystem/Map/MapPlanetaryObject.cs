using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.PlanetarySystem.Map
{
    public class MapPlanetaryObject : MonoBehaviour
    {

        [SerializeField] private FollowObjectOnCanvas m_FollowObjectOnCanvas;


        public event Action<PlanetData> OnButtonClickHandler = delegate { };
        [SerializeField] private Button m_Button;
        private PlanetController _planetController;
        private PlanetarySystemObject _planetarySystemObject;

        private void Awake()
        {
            m_Button.onClick.AddListener(() => OnButtonClickHandler.Invoke(_planetController.PlanetData));
        }

        public void SetPlanetData(PlanetController planetData)
        {
            _planetController = planetData;
            m_FollowObjectOnCanvas.TargetFollow = planetData.PlanetObject;
            _planetarySystemObject = planetData.PlanetObject.GetComponent<PlanetarySystemObject>();
            if(_planetarySystemObject != null)
            {
                _planetarySystemObject.OnChangeStatus += OnChangeStatus;
            }
        }

        private void OnChangeStatus()
        {
            m_Button.image.enabled = _planetarySystemObject.Status;
        }

        private void OnDestroy()
        {
            _planetarySystemObject.OnChangeStatus -= OnChangeStatus;
        }
    }
}
