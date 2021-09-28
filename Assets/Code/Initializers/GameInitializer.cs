using UnityEngine;
using Interfaces;
using Controllers;
using Controllers.Inputting;
using Controllers.Services;
using Models.Managers;
using Models.ScriptableObjects;
using Models.Constructables.ConfigurationModels;
using Spawnables.Services;

namespace Initializers
{

    public class GameInitializer : IGameInitializer
    {

        #region Constructors

        public GameInitializer(string gameConfigurationDirectory, ControllersList controllersList, Transform rootTransform, RectTransform userInterfaceTransform, Transform audioTransform)
        {

            var gameConfiguration           = new GameConfigurationModel(gameConfigurationDirectory, rootTransform);
            var gameStateController         = new GameStateController();
            var audioServiceController      = new AudioServiceController(gameConfiguration.Audio, audioTransform, gameStateController);
            var inputUnitManager            = new InputUnitManager();
            var inputController             = new InputController(inputUnitManager);
            var poolService                 = new PoolService(gameConfiguration.ScreenMap.PoolServiceTransform);
            var healthServiceController     = new HealthServiceController();
            var pointsController            = new PointsController();
            var gameEventsHandler           = new GameEventsHandler();
            var projectileServiceController = new ProjectileServiceController(poolService, gameStateController);
            
            new PlayerInitializer(gameConfiguration, gameConfiguration.ScreenMap, controllersList, poolService, inputUnitManager, healthServiceController, projectileServiceController, gameEventsHandler, gameStateController, audioServiceController);

            new EnemyInitializer(gameConfiguration, controllersList, poolService, healthServiceController, gameConfiguration.ScreenMap.EnemiesRoutesContainer.Routes, projectileServiceController, pointsController, gameEventsHandler, gameStateController, audioServiceController);

            new UserInterfaceInitializer(gameConfiguration, controllersList, userInterfaceTransform, gameEventsHandler, pointsController);

            new BackgroundInitializer(gameConfiguration.Background, controllersList, poolService);

            inputUnitManager.Restart.AddHandler(gameEventsHandler.StartGame);

            gameEventsHandler.AddRestartHandler(inputController.StartGame);
            gameEventsHandler.AddRestartHandler(projectileServiceController.StartGame);
            gameEventsHandler.AddRestartHandler(pointsController.NullifyPoints);
            gameEventsHandler.AddRestartHandler(gameStateController.StartGame);
            gameEventsHandler.AddRestartHandler(audioServiceController.StartGame);
            
            gameEventsHandler.AddGameOverHandler(projectileServiceController.StopGame);
            gameEventsHandler.AddGameOverHandler(inputController.StopGame);
            gameEventsHandler.AddGameOverHandler(gameStateController.StopGame);
            gameEventsHandler.AddGameOverHandler(audioServiceController.StopGame);

            gameEventsHandler.StartGame();

            controllersList.AddController(projectileServiceController);
            controllersList.AddController(inputController);
            controllersList.AddController(audioServiceController);

        }

        #endregion

    }

}