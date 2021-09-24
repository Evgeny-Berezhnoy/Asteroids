using System.Collections.Generic;
using Constants;
using Controllers;
using Controllers.Services;
using Interfaces;
using Models.ScriptableObjects;
using Models.Constructables;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Initializers
{   

    public class EnemyInitializer : IGameInitializer
    {

        #region Constructors

        public EnemyInitializer(GameConfiguration gameConfiguration, ControllersList controllersList, PoolService poolService, HealthServiceController healthServiceController, List<RouteModel> enemiesRoutes, ProjectileServiceController projectileServiceController)
        {

            List<EnemyConfiguration> enemies    = gameConfiguration.EnemiesStorage.Enemies;
            var enemiesSpawners                 = new List<EnemySpawner>();
            
            for (int i = 0; i < enemies.Count; i++)
            {

                EnemyConfiguration enemyConfiguration = enemies[i];

                ShooterConfiguration shooterConfiguration = enemyConfiguration.ShooterConfiguration;

                string poolSpaceName = PoolNames.ENEMY_POOL_PREFIX + shooterConfiguration.Projectile.GameobjectName;

                if (!poolService.TryGetSpawner(poolSpaceName, out var projectileSpawner))
                {

                    projectileSpawner = new ProjectileSpawner(shooterConfiguration.Projectile, poolSpaceName, LayerMasks.ENEMY_PROJECTILE, healthServiceController);

                    poolService.CreatePool(projectileSpawner);
                    
                };

                var enemySpawner = new EnemySpawner(enemyConfiguration, projectileSpawner, poolService, healthServiceController, projectileServiceController);

                poolService.CreatePool(enemySpawner);

                enemiesSpawners.Add(enemySpawner);

            };

            var enemyServiceController  = new EnemyServiceController(enemiesSpawners, enemiesRoutes, gameConfiguration.EnemiesStorage.SpawnCooldown, poolService);

            controllersList.AddController(enemyServiceController);

        }

        #endregion

    }

}
