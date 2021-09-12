using System.Collections.Generic;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Interfaces;
using Models.ScriptableObjects;
using Models.Constructables;
using Views.Components;

namespace Initializers
{
    public class ScreenMapInitializer : IGameInitializer
    {

        #region Constructors

        public ScreenMapInitializer(GameConfiguration gameConfiguration, Transform rootTransform, out ScreenMapModel screenMapModel)
        {

            screenMapModel = CreateMapModel(gameConfiguration.ScreenMapPrefab, rootTransform);

        }

        #endregion

        #region Methods

        private ScreenMapModel CreateMapModel(ScreenMap screenMap, Transform rootTransform)
        {

            ScreenMapModel screenMapModel = new ScreenMapModel(rootTransform);

            screenMapModel.PlayerStartTransform.SetPositionAndRotation(screenMap.PlayerStartPoint);

            for(int i = 0; i < screenMap.EnemiesRoutes.Count; i++)
            {

                List<Transform> routeTransforms = screenMap.EnemiesRoutes[i].Destinations;

                RouteModel route = new RouteModel();

                Transform enemyRouteTransform = new GameObject(GameobjectNames.ROUTE).transform;

                enemyRouteTransform.SetParent(screenMapModel.EnemiesRoutesTransform);
                enemyRouteTransform.SetLocalPositionAndRotation();

                for(int j = 0; j < routeTransforms.Count; j++)
                {

                    Transform destination = new GameObject(GameobjectNames.ROUTE_DESTINATION).transform;

                    destination.SetParent(enemyRouteTransform);
                    destination.SetPositionAndRotation(routeTransforms[j]);

                    route.Destinations.AddLast(destination);

                };

                screenMapModel.EnemiesRoutesContainer.Routes.Add(route);

            };

            return screenMapModel;

        }

        #endregion

    }

}