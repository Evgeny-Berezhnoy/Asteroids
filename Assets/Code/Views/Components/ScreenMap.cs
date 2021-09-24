using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Views.Templates;

namespace Views.Components
{
    [Serializable]
    public class ScreenMap : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private List<Route> _enemiesRoutes;
        #endregion

        #region Properties

        public Transform PlayerStartPoint => _playerStartPoint;
        public List<Route> EnemiesRoutes => _enemiesRoutes;

        #endregion

        #region Events

        private void OnDrawGizmosSelected()
        {

            #if UNITY_EDITOR

            Gizmos.color = new Color(1, 0, 0);

            for(int i = 0; i < _enemiesRoutes.Count; i++)
            {

                List<Transform> destinations = _enemiesRoutes[i].Destinations;

                if (destinations.Any(x => x == null))
                {

                    Debug.LogError($"Screen map: Enemy route {i} is not closed-circuit.");

                    continue;

                }

                for(int j = 1; j < destinations.Count; j++)
                {

                    Gizmos.DrawLine(destinations[j - 1].position, destinations[j].position);

                };

            };

            #endif

        }

        #endregion

    }

}