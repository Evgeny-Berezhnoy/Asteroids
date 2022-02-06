using System;
using System.Collections.Generic;

namespace Models.Constructables
{
    [Serializable]
    public class RouteContainer
    {
        #region Fields

        public List<RouteModel> Routes;

        #endregion

        #region Constructors

        public RouteContainer()
        {
            Routes = new List<RouteModel>();
        }

        #endregion
    }
}