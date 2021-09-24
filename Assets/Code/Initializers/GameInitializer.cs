using UnityEngine;
using Interfaces;
using Controllers;
using Controllers.Inputting;
using Controllers.Services;
using Models.Managers;
using Models.ScriptableObjects;
using Spawnables.Services;

namespace Initializers
{

    public class GameInitializer : IGameInitializer
    {

        #region Constructors

        public GameInitializer(GameConfiguration gameConfiguration, ControllersList controllersList, Transform rootTransform, RectTransform userInterfaceTransform)
        {

            gameConfiguration.Initialize();

            var inputUnitManager            = new InputUnitManager();
            var inputController             = new InputController(inputUnitManager);
            var gameStateController         = new GameStateController();
            var poolService                 = new PoolService();
            var projectileServiceController = new ProjectileServiceController(poolService, gameStateController);
            var healthServiceController     = new HealthServiceController();
            var pointsController            = new PointsController();
            var gameEventsHandler           = new GameEventsHandler();
            
            new ScreenMapInitializer(gameConfiguration, rootTransform, out var screenMapModel);

            new PlayerInitializer(gameConfiguration, screenMapModel, controllersList, poolService, inputUnitManager, healthServiceController, projectileServiceController, gameEventsHandler, gameStateController);

            new EnemyInitializer(gameConfiguration, controllersList, poolService, healthServiceController, screenMapModel.EnemiesRoutesContainer.Routes, projectileServiceController, pointsController, gameEventsHandler, gameStateController);

            new UserInterfaceInitializer(gameConfiguration, controllersList, userInterfaceTransform, gameEventsHandler, pointsController);

            inputUnitManager.Restart.AddHandler(gameEventsHandler.StartGame);

            gameEventsHandler.AddRestartHandler(inputController.StartGame);
            gameEventsHandler.AddRestartHandler(projectileServiceController.StartGame);
            gameEventsHandler.AddRestartHandler(pointsController.NullifyPoints);
            gameEventsHandler.AddRestartHandler(gameStateController.StartGame);

            gameEventsHandler.AddGameOverHandler(projectileServiceController.StopGame);
            gameEventsHandler.AddGameOverHandler(inputController.StopGame);
            gameEventsHandler.AddGameOverHandler(gameStateController.StopGame);
            
            gameEventsHandler.StartGame();

            controllersList.AddController(projectileServiceController);
            controllersList.AddController(inputController);

        }

        #endregion

    }

}
