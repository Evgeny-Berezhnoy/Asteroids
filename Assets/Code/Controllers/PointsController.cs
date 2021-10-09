using System.Collections.Generic;
using System.Linq;
using Interpreters;
using Interfaces;
using Interfaces.Events;

namespace Controllers
{

    public class PointsController : IController
    {

        #region Delegates

        public delegate void ChangePoints(string points);

        #endregion

        #region Events

        private event ChangePoints _onChangingPoints;

        #endregion

        #region Fields

        private int _points;

        private List<ChangePoints> _onChangingPointsHandlers;

        #endregion

        #region Constructors

        public PointsController()
        {

            _points = 0;

            _onChangingPointsHandlers = new List<ChangePoints>();

        }

        #endregion

        #region

        public void AddPoints(int points)
        {

            _points += points;

            _onChangingPoints?.Invoke(GamePoints.GetRepresentation(_points));

        }

        public void NullifyPoints()
        {

            _points = 0;

            _onChangingPoints?.Invoke(GamePoints.GetRepresentation(_points));
            
        }

        public void AddPointsHandler(ChangePoints handler)
        {

            _onChangingPointsHandlers.Add(handler);

            _onChangingPoints += handler;

        }

        public void RemovePointsHandler(ChangePoints handler)
        {

            if (!_onChangingPointsHandlers.Any(x => x.Equals(handler)))
            {

                return;

            }

            _onChangingPoints -= handler;

            _onChangingPointsHandlers.Remove(handler);

        }

        public void RemoveAllPointsHandlers()
        {

            for (var i = 0; i < _onChangingPointsHandlers.Count; i++)
            {

                _onChangingPoints -= _onChangingPointsHandlers[i];

            };

            _onChangingPointsHandlers.Clear();

        }

        #endregion

    }

}