using System.Collections.Generic;
using UnityEngine;
using Constants;
using Controllers;
using Controllers.Services;
using Controllers.Shooters;
using Interfaces;
using Models.Constructables;
using Models.ScriptableObjects;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Initializers
{
    public class PlayerShooterInitializer : IGameInitializer
    {

        #region Constructors

        public PlayerShooterInitializer(ShootersStorage shootersStorage, Transform playerTransform, ControllersList controllersList, PoolService poolService, InputController inputController, HealthServiceController healthServiceController, ProjectileServiceController projectileServiceController)
        {

            var shooterModels = new LinkedList<ShooterModel>();

            for(int i = 0; i < shootersStorage.Shooters.Count; i++)
            {

                ShooterConfiguration shooterConfiguration = shootersStorage.Shooters[i];

                string poolSpaceName = PoolNames.PLAYER_POOL_PREFIX + shooterConfiguration.Projectile.GameobjectName;

                var shooterModel = new ShooterModel();

                shooterModel.Cooldown       = shooterConfiguration.Cooldown;   
                shooterModel.ShootingPoints = new ShooterMapModel(playerTransform, shooterConfiguration.ShooterMap.ShootingPoints, shooterConfiguration.Name).ShootingPoints;

                if(!poolService.TryGetSpawner(poolSpaceName, out var projectileSpawner))
                {

                    projectileSpawner = new ProjectileSpawner(shooterConfiguration.Projectile, poolSpaceName, LayerMasks.PLAYER_PROJECTILE, healthServiceController);
                    
                    poolService.CreatePool(projectileSpawner);
                    
                }

                shooterModel.Spawner = projectileSpawner;

                shooterModels.AddLast(shooterModel);

            }

            var playerShooterController     = new PlayerShooterController(poolService, projectileServiceController);
            var shooterSwapperController    = new ShooterSwapperController(playerShooterController, shooterModels);

            inputController.AddShootHandler(playerShooterController.Shoot);
            inputController.AddWheelScrollHandler(shooterSwapperController.ChangeWeapon);

            controllersList.AddController(playerShooterController);

        }

        #endregion

    }

}
