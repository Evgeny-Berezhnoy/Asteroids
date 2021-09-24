using System.Collections.Generic;
using UnityEngine;
using Controllers;
using Controllers.Services;
using Controllers.Shooters;
using ExtensionCompilation;
using Interfaces;
using Models.ScriptableObjects;
using Models.Constructables;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Initializers
{
    public class PlayerInitializer : IGameInitializer
    {

        #region Constructors

        public PlayerInitializer(GameConfiguration gameConfiguration, ScreenMapModel screenMapModel, ControllersList controllersList, PoolService poolService, InputController inputController, HealthServiceController healthServiceController, ProjectileServiceController projectileServiceController)
        {

            var playerController = CreatePlayerController(screenMapModel.PlayerStartTransform, gameConfiguration.PlayerConfiguration, inputController, healthServiceController);

            new PlayerShooterInitializer(gameConfiguration.ShootersStorage, playerController.Gameobject.transform, controllersList, poolService, inputController, healthServiceController, projectileServiceController);

        }

        #endregion

        #region Methods
        
        private PlayerController CreatePlayerController(Transform playerTransform, PlayerConfiguration playerConfiguration, InputController inputController, HealthServiceController healthServiceController)
        {

            PlayerSpawner playerSpawner = new PlayerSpawner(playerConfiguration, healthServiceController);

            var playerController = playerSpawner.Spawn() as PlayerController;

            playerController.Gameobject.transform.SetPositionAndRotation(playerTransform);

            inputController.AddAxisHandler(playerController.MoveController.Move);

            return playerController;

        }
        
        #endregion

    }

}