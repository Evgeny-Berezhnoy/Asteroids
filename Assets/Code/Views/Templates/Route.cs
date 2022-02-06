using System;
using System.Collections.Generic;
using UnityEngine;

namespace Views.Templates
{
    [Serializable]
    public class Route
    {
        #region Fields

        public List<Transform> Destinations;

        #endregion

        #region Constructors

        public Route()
        {
            Destinations = new List<Transform>();
        }

        #endregion
    }
}