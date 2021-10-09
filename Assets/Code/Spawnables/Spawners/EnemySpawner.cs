using UnityEngine;
using Constants;
using Controllers;
using Controllers.Services;
using Controllers.Shooters;
using ExtensionCompilation;
using Interfaces;
using Models.Constructables;
using Models.Constructables.ConfigurationModels;
using Spawnables.Services;
using Spawnables.Spawners.Templates;

namespace Spawnables.Spawners
{
    public class EnemySpawner : Spawner<EnemyConfigurationModel>
    {

        #region Fields

        private ISpawner _projectileSpawner;
        private PoolService _poolService;
        private HealthServiceController _healthServiceController;
        private ProjectileServiceController _projectileServiceController;
        private PointsController _pointsController;

        #endregion

        #region Constructors

        public EnemySpawner(IPrefabData prefab, ISpawner projectileSpawner, PoolService poolService, HealthServiceController healthServiceController, ProjectileServiceController projectileServiceController, PointsController pointsController) : base(prefab, prefab.GameobjectName)
        {

            _projectileSpawner              = projectileSpawner;
            _poolService                    = poolService;
            _healthServiceController        = healthServiceController;
            _projectileServiceController    = projectileServiceController;
            _pointsController               = pointsController;

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

            shooterModel.Cooldown       = _prefab.Shooter.Cooldown;
            shooterModel.Spawner        = _projectileSpawner;
            shooterModel.ShootingPoints = new ShooterMapModel(gameObject.transform, _prefab.Shooter).ShootingPoints;

            EnemyShooterController enemyShooterController = new EnemyShooterController(_poolService, shooterModel, _projectileServiceController); 

            EnemyController enemyController = new EnemyController(gameObject, _prefab, enemyShooterController, _pointsController);

            _healthServiceController.Insert(gameObject, enemyController.HealthController);

            return enemyController;

        }

        #endregion

    }

}
