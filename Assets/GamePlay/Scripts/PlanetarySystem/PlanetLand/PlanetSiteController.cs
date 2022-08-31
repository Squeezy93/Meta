using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.PlanetarySystem.PlanetLand
{
    public class PlanetSiteController : MonoBehaviour
    {
        public void SetData(SitePlanetData sitePlanetData)
        {
            GetComponentInChildren<Text>().text = sitePlanetData.Name;
        }
    }

}
