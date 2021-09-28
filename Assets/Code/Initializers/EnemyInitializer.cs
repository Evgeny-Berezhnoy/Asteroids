using System.Collections.Generic;
using Constants;
using Controllers;
using Controllers.Services;
using Interfaces;
using Models.Constructables;
using Models.Constructables.ConfigurationModels;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Initializers
{   

    public class EnemyInitializer : IGameInitializer
    {

        #region Constructors

        public EnemyInitializer(GameConfigurationModel gameConfiguration,
                                ControllersList controllersList,
                                PoolService poolService,
                                HealthServiceController healthServiceController,
                                List<RouteModel> enemiesRoutes,
                                ProjectileServiceController projectileServiceController,
                                PointsController pointsController,
                                GameEventsHandler gameEventsHandler,
                                GameStateController gameStateController,
                                AudioServiceController audioServiceController)
        {

            var enemiesSpawners = new List<EnemySpawner>();
            
            for (int i = 0; i < gameConfiguration.Enemies.Count; i++)
            {

                EnemyConfigurationModel enemyConfiguration = gameConfiguration.Enemies[i];

                ShooterConfigurationModel shooterConfiguration = enemyConfiguration.Shooter;

                string poolSpaceName = PoolNames.ENEMY_POOL_PREFIX + shooterConfiguration.Projectile.GameobjectName;

                if (!poolService.TryGetSpawner(poolSpaceName, out var projectileSpawner))
                {

                    projectileSpawner = new ProjectileSpawner(shooterConfiguration.Projectile, poolSpaceName, LayerMasks.ENEMY_PROJECTILE, healthServiceController, audioServiceController);

                    poolService.CreatePool(projectileSpawner);
                    
                };

                var enemySpawner = new EnemySpawner(enemyConfiguration, projectileSpawner, poolService, healthServiceController, projectileServiceController, pointsController);

                poolService.CreatePool(enemySpawner);

                enemiesSpawners.Add(enemySpawner);

            };

            var enemyServiceController  = new EnemyServiceController(enemiesSpawners, enemiesRoutes, gameConfiguration.EnemiesSpawnCooldown, poolService, gameStateController);

            gameEventsHandler.AddRestartHandler(enemyServiceController.StartGame);
            gameEventsHandler.AddGameOverHandler(enemyServiceController.StopGame);

            controllersList.AddController(enemyServiceController);

        }

        #endregion

    }

}
