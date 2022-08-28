using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.PlanetarySystem
{
    [CreateAssetMenu(menuName = "PlanetarySystem/Planet database")]
    public class PlanetDatabase : ScriptableObject
    {
        [SerializeField] private string _planetarySystemName;
        [SerializeField] private List<PlanetData> _planetDatas;
        public List<PlanetData> PlanetDatas => _planetDatas;
    }
}
