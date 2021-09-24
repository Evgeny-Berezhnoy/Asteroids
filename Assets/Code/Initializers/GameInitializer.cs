using UnityEngine;
using Interfaces;
using Controllers;
using Controllers.Services;
using Models.ScriptableObjects;
using Spawnables.Services;

namespace Initializers
{

    public class GameInitializer : IGameInitializer
    {

        #region Constructors

        public GameInitializer(GameConfiguration gameConfiguration, ControllersList controllersList, Transform rootTransform)
        {

            gameConfiguration.Initialize();

            var inputController             = new InputController();
            var poolService                 = new PoolService();
            var healthServiceController     = new HealthServiceController();
            var projectileServiceController = new ProjectileServiceController(poolService);

            new ScreenMapInitializer(gameConfiguration, rootTransform, out var screenMapModel);

            new PlayerInitializer(gameConfiguration, screenMapModel, controllersList, poolService, inputController, healthServiceController, projectileServiceController);

            new EnemyInitializer(gameConfiguration, controllersList, poolService, healthServiceController, screenMapModel.EnemiesRoutesContainer.Routes, projectileServiceController);

            controllersList.AddController(projectileServiceController);
            controllersList.AddController(inputController);

        }

        #endregion

    }

}
