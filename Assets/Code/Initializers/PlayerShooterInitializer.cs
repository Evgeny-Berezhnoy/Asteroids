using System.Collections.Generic;
using UnityEngine;
using Constants;
using Controllers;
using Controllers.Services;
using Controllers.Shooters;
using Interfaces;
using Models.Constructables;
using Models.Constructables.ConfigurationModels;
using Models.Managers;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Initializers
{
    public class PlayerShooterInitializer : IGameInitializer
    {
        #region Constructors

        public PlayerShooterInitializer(List<ShooterConfigurationModel> shooters,
                                        Transform playerTransform,
                                        ControllersList controllersList,
                                        PoolService poolService,
                                        InputUnitManager inputUnitManager,
                                        HealthServiceController healthServiceController,
                                        ProjectileServiceController projectileServiceController,
                                        GameEventsHandler gameEventsHandler,
                                        GameStateController gameStateController,
                                        AudioServiceController audioServiceController)
        {
            var shooterModels = new LinkedList<ShooterModel>();

            for(int i = 0; i < shooters.Count; i++)
            {
                ShooterConfigurationModel shooterConfiguration = shooters[i];

                string poolSpaceName = PoolNames.PLAYER_POOL_PREFIX + shooterConfiguration.Projectile.GameobjectName;

                var shooterModel = new ShooterModel();

                shooterModel.Cooldown       = shooterConfiguration.Cooldown;   
                shooterModel.ShootingPoints = new ShooterMapModel(playerTransform, shooterConfiguration.ShooterMap.ShootingPoints, shooterConfiguration.GameobjectName).ShootingPoints;

                if(!poolService.TryGetSpawner(poolSpaceName, out var projectileSpawner))
                {
                    projectileSpawner = new ProjectileSpawner(shooterConfiguration.Projectile, poolSpaceName, LayerMasks.PLAYER_PROJECTILE, healthServiceController, audioServiceController);
                    
                    poolService.CreatePool(projectileSpawner);    
                }

                shooterModel.Spawner = projectileSpawner;

                shooterModels.AddLast(shooterModel);
            }

            var playerShooterController     = new PlayerShooterController(poolService, projectileServiceController, gameStateController);
            var shooterSwapperController    = new ShooterSwapperController(playerShooterController, shooterModels);

            inputUnitManager.GameShoot.AddHandler(playerShooterController.Shoot);
            inputUnitManager.GameWheel.AddHandler(shooterSwapperController.ChangeWeapon);

            gameEventsHandler.AddRestartHandler(playerShooterController.StartGame);
            gameEventsHandler.AddGameOverHandler(playerShooterController.StopGame);

            controllersList.AddController(playerShooterController);
        }

        #endregion
    }
}