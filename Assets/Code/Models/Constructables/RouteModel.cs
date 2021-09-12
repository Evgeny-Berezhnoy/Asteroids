using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models.Constructables
{

    [Serializable]
    public class RouteModel
    {

        #region Fields

        public LinkedList<Transform> Destinations;

        #endregion

        #region Constructors

        public RouteModel()
        {

            Destinations = new LinkedList<Transform>();

        }

        #endregion

    }

}