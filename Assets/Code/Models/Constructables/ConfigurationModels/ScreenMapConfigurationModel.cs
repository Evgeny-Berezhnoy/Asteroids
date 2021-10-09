using System.Collections.Generic;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Models.Constructables.Templates;
using Views.Components;

namespace Models.Constructables.ConfigurationModels
{

    public class ScreenMapConfigurationModel : ConfigurationModel
    {

        #region Properties

        public Transform ModelTransform;
        public Transform PlayerStartTransform;
        public Transform EnemiesRoutesTransform;
        public Transform PoolServiceTransform;
        public RouteContainer EnemiesRoutesContainer;

        #endregion

        #region Constructors

        public ScreenMapConfigurationModel(string configurationDirectory, Transform rootTransform) : base(configurationDirectory)
        {

            CreateTransforms(rootTransform);
            ConstructMap(configurationDirectory);

        }

        #endregion

        #region Methods

        private void CreateTransforms(Transform rootTransform)
        {

            ModelTransform = new GameObject(GameobjectNames.SCREEN_MAP_MODEL).transform;
            ModelTransform.SetParent(rootTransform);
            ModelTransform.SetLocalPositionAndRotation();

            PlayerStartTransform = new GameObject(GameobjectNames.PLAYER_START_POINT).transform;
            PlayerStartTransform.SetParent(ModelTransform);

            EnemiesRoutesTransform = new GameObject(GameobjectNames.ENEMY_ROUTES).transform;
            EnemiesRoutesTransform.SetParent(ModelTransform);
            EnemiesRoutesTransform.SetLocalPositionAndRotation();

            PoolServiceTransform = new GameObject(GameobjectNames.POOL_SERVICE).transform;
            PoolServiceTransform.SetParent(ModelTransform);

        }

        private void ConstructMap(string configurationDirectory)
        {

            var screenMap = ModelsInitializer.LoadObject<GameObject>(configurationDirectory).GetComponent<ScreenMap>();

            EnemiesRoutesContainer = new RouteContainer();

            PlayerStartTransform.SetPositionAndRotation(screenMap.PlayerStartPoint);
            PoolServiceTransform.SetPositionAndRotation(screenMap.PoolService);

            for (int i = 0; i < screenMap.EnemiesRoutes.Count; i++)
            {

                List<Transform> routeTransforms = screenMap.EnemiesRoutes[i].Destinations;

                RouteModel route = new RouteModel();

                Transform enemyRouteTransform = new GameObject(GameobjectNames.ROUTE).transform;

                enemyRouteTransform.SetParent(EnemiesRoutesTransform);
                enemyRouteTransform.SetLocalPositionAndRotation();

                for (int j = 0; j < routeTransforms.Count; j++)
                {

                    Transform destination = new GameObject(GameobjectNames.ROUTE_DESTINATION).transform;

                    destination.SetParent(enemyRouteTransform);
                    destination.SetPositionAndRotation(routeTransforms[j]);

                    route.Destinations.AddLast(destination);

                };

                EnemiesRoutesContainer.Routes.Add(route);

            };

        }

        #endregion

    }

}