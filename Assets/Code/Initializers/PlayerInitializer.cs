using Controllers;
using Controllers.Services;
using Interfaces;
using Models.Constructables;
using Models.Managers;
using Models.ScriptableObjects;
using Spawnables.Services;

namespace Initializers
{
    public class PlayerInitializer : IGameInitializer
    {

        #region Constructors

        public PlayerInitializer(GameConfiguration gameConfiguration,
                                    ScreenMapModel screenMapModel,
                                    ControllersList controllersList,
                                    PoolService poolService,
                                    InputUnitManager inputUnitManager,
                                    HealthServiceController healthServiceController,
                                    ProjectileServiceController projectileServiceController,
                                    GameEventsHandler gameEventsHandler,
                                    GameStateController gameStateController)
        {

            var playerServiceController = new PlayerServiceController(screenMapModel.PlayerStartTransform, gameConfiguration.PlayerConfiguration, poolService, healthServiceController, gameStateController);

            new PlayerShooterInitializer(gameConfiguration.ShootersStorage, playerServiceController.PlayerController.Gameobject.transform, controllersList, poolService, inputUnitManager, healthServiceController, projectileServiceController, gameEventsHandler, gameStateController);

            playerServiceController.OnPlayersDeath += gameEventsHandler.StopGame;
            
            inputUnitManager.GameAxis.AddHandler(playerServiceController.PlayerController.MoveController.Move);

            gameEventsHandler.AddRestartHandler(playerServiceController.StartGame);
            gameEventsHandler.AddGameOverHandler(playerServiceController.StopGame);

            controllersList.AddController(playerServiceController);

        }

        #endregion

    }

}