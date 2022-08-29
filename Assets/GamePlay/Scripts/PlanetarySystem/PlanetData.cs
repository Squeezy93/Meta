using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.PlanetarySystem
{
    [Serializable]
    public class PlanetData
    {
        public string PlanetId;
        public Vector3 PlanetVectorPosition;
        public Vector3 PlanetAngleMove;

        public float PlanetSize;
    }
}
