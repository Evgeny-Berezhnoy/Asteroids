using Controllers;
using Controllers.Services;
using Interfaces;
using Models.Managers;
using Models.Constructables.ConfigurationModels;
using Spawnables.Services;

namespace Initializers
{
    public class PlayerInitializer : IGameInitializer
    {
        #region Constructors

        public PlayerInitializer(GameConfigurationModel gameConfiguration,
                                    ScreenMapConfigurationModel screenMapModel,
                                    ControllersList controllersList,
                                    PoolService poolService,
                                    InputUnitManager inputUnitManager,
                                    HealthServiceController healthServiceController,
                                    ProjectileServiceController projectileServiceController,
                                    GameEventsHandler gameEventsHandler,
                                    GameStateController gameStateController,
                                    AudioServiceController audioServiceController)
        {
            var playerServiceController = new PlayerServiceController(screenMapModel.PlayerStartTransform, gameConfiguration.Player, poolService, healthServiceController, gameStateController);

            new PlayerShooterInitializer(gameConfiguration.Shooters,
                                            playerServiceController.PlayerController.Gameobject.transform,
                                            controllersList,
                                            poolService,
                                            inputUnitManager,
                                            healthServiceController,
                                            projectileServiceController,
                                            gameEventsHandler,
                                            gameStateController,
                                            audioServiceController);

            playerServiceController.OnPlayersDeath += gameEventsHandler.StopGame;
            
            inputUnitManager.GameAxis.AddHandler(playerServiceController.PlayerController.MoveController.Move);

            gameEventsHandler.AddRestartHandler(playerServiceController.StartGame);
            gameEventsHandler.AddGameOverHandler(playerServiceController.StopGame);

            controllersList.AddController(playerServiceController);
        }

        #endregion
    }
}