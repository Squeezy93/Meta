using GamePlay.GameStatus;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.PlanetarySystem.PlanetLand
{
    public class PlanetViewController : MonoBehaviour
    {

        [SerializeField] private List<PlanetSiteController> m_LandSiteControllers = new List<PlanetSiteController>();
        [SerializeField] private List<PlanetSiteController> m_PlayerSiteControllers = new List<PlanetSiteController>();
        [SerializeField] private Button m_ButtonFlyout;

        [SerializeField] private Transform m_Side1;
        [SerializeField] private Transform m_Side2;
        private void Awake()
        {
            InitLocalSite();
            m_ButtonFlyout.onClick.AddListener(FlyAway);
        }

        [ContextMenu("collect")]
        private void CollectSite()
        {
            m_LandSiteControllers = transform.GetChild(1).GetComponentsInChildren<PlanetSiteController>().ToList();
            m_PlayerSiteControllers = transform.GetChild(2).GetComponentsInChildren<PlanetSiteController>().ToList();
        }

        private void OnEnable()
        {
            m_Side1.gameObject.SetActive(true);
            m_Side2.gameObject.SetActive(false);
        }

        private void InitLocalSite()
        {
            m_LandSiteControllers[0].SetData(new SitePlanetData() { Name = "Космодром" });
            m_LandSiteControllers[1].SetData(new SitePlanetData() { Name = "Ангар" });
            m_LandSiteControllers[2].SetData(new SitePlanetData() { Name = "Правительство" });         

            m_LandSiteControllers[m_LandSiteControllers.Count - 3].SetData(new SitePlanetData() { Name = "Рынок ресурсов" });
            m_LandSiteControllers[m_LandSiteControllers.Count - 2].SetData(new SitePlanetData() { Name = "Рынок оборудования" });
            m_LandSiteControllers[m_LandSiteControllers.Count - 1].SetData(new SitePlanetData() { Name = "Справочная" });
        }

        public void InitHexes(List<SitePlanetData> landData, List<SitePlanetData> playerSiteData)
        {         

            for (int i = 0; i < m_LandSiteControllers.Count-3; i++)
            {
                m_LandSiteControllers[3 + i].SetData(landData[i]);
            }          

            for (int i = 0; i < m_PlayerSiteControllers.Count; i++)
            {
                m_PlayerSiteControllers[3 + i].SetData(playerSiteData[i]);
            }
        }

        private void FlyAway()
        {
            GameManager.SetStatus(new PlanetSystemSpace() { });
        }
    }
}
