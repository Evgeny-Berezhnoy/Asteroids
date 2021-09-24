using UnityEngine;
using Constants;
using Controllers;
using Controllers.Services;
using Controllers.Shooters;
using ExtensionCompilation;
using Interfaces;
using Models.Constructables;
using Models.ScriptableObjects;
using Spawnables.Services;
using Spawnables.Spawners.Templates;

namespace Spawnables.Spawners
{
    public class EnemySpawner : Spawner<EnemyConfiguration>
    {

        #region Fields

        private ISpawner _projectileSpawner;
        private PoolService _poolService;
        private HealthServiceController _healthServiceController;
        private ProjectileServiceController _projectileServiceController;

        #endregion

        #region Constructors

        public EnemySpawner(EnemyConfiguration prefab, ISpawner projectileSpawner, PoolService poolService, HealthServiceController healthServiceController, ProjectileServiceController projectileServiceController) : base(prefab, prefab.GameobjectName)
        {

            _projectileSpawner              = projectileSpawner;
            _poolService                    = poolService;
            _healthServiceController        = healthServiceController;
            _projectileServiceController    = projectileServiceController;   

        }

        #endregion

        #region Interfaces Methods

        public override ISpawnableObject Spawn()
        {

            GameObject gameObject = new GameObject(_prefabName);

            gameObject
                .AddSpriteRendererAbsent(_prefab.Sprite, OrdersInLayers.ENEMY)
                .AddCircleCollider2DAbsent();

            gameObject.layer = Layers.ENEMY;

            var shooterModel = new ShooterModel();

            shooterModel.Cooldown       = _prefab.ShooterConfiguration.Cooldown;
            shooterModel.Spawner        = _projectileSpawner;
            shooterModel.ShootingPoints = new ShooterMapModel(gameObject.transform, _prefab.ShooterConfiguration).ShootingPoints;

            EnemyShooterController enemyShooterController = new EnemyShooterController(_poolService, shooterModel, _projectileServiceController); 

            EnemyController enemyController = new EnemyController(gameObject, _prefab, enemyShooterController);

            _healthServiceController.Insert(gameObject, enemyController.HealthController);

            return enemyController;

        }

        #endregion

    }

}
