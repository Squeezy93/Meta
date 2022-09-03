using GamePlay.SpaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.PlanetarySystem.PlanetLand
{
    public class PlanetSiteController : MonoBehaviour
    {
        private Button _button;
        private Text _title;
        private SitePlanetData _sitePlanetData;
     

        private void Awake()
        {
            _button = GetComponent<Button>();
            _title = GetComponentInChildren<Text>();
            _button.onClick.AddListener(OpenView);
        }

        public void SetData(SitePlanetData sitePlanetData)
        {
            _sitePlanetData = sitePlanetData;
            
            
        }

        private void OnEnable()
        {
            if(_sitePlanetData != null)
                _title.text = _sitePlanetData.Name;
        }

        private void OpenView()
        {
            if (_sitePlanetData != null)
                InterfaceManager.OpenView(_sitePlanetData.InterfaceWindowKey);
        }
    }

}
