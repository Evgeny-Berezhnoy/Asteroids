using System.Collections.Generic;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Interfaces;
using Interfaces.Events;
using Models.Constructables;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Controllers.Services
{
    public class EnemyServiceController : IController, IUpdate, IPoolServiceController, ICooldown
    {

        #region Fields

        private List<EnemyController> _enemies;
        private List<RouteModel> _enemiesRoutes;
        private PoolService _poolService;
        private EnemySpawner _currentSpawner;
        
        #endregion

        #region Properties

        public List<EnemySpawner> EnemySpawners { get; set; }
        
        #endregion

        #region Interfaces Properties

        public PoolService PoolService => _poolService;
        public float Cooldown { get; set; }
        public float CurrentCooldown { get; set; }

        #endregion

        #region Constructors

        public EnemyServiceController(List<EnemySpawner> enemySpawners, List<RouteModel> enemiesRoutes, float cooldown, PoolService poolService)
        {

            EnemySpawners   = enemySpawners;
            
            _poolService    = poolService;
            _enemies        = new List<EnemyController>();
            
            Cooldown        = cooldown;
            CurrentCooldown = 0;

            _enemiesRoutes  = enemiesRoutes;

        }

        #endregion

        #region Methods
        
        private void CheckoutSpawnableObjects(float deltaTime)
        {

            for (int i = _enemies.Count - 1; i >= 0; i--)
            {

                var enemy = _enemies[i];

                if (!enemy.Gameobject.activeSelf)
                {

                    ReturnToPool(enemy);

                    return;

                };

                if (enemy is IUpdate updateController)
                {

                    updateController.OnUpdate(deltaTime);

                };

            };

        }

        private void SetRandomSpawner()
        {

            var randomizer = new System.Random();

            int spawnerIndex = randomizer.Next(EnemySpawners.Count - 1);

            _currentSpawner = EnemySpawners[spawnerIndex];

        }

        private void CreateFromPool(ISpawner spawner)
        {

            if (!_poolService.TryInstantiate(spawner.PrefabName, out var spawnableObject))
            {

                Debug.LogError(ErrorMessages.SpawnableObjectCreate(spawner.PrefabName));

                return;

            }

            var enemyController = spawnableObject as EnemyController;

            enemyController.HealthController.Resurect();

            if (enemyController.MoveController is INavigable navigableMoveController)
            {

                RouteModel route = _enemiesRoutes.Random();

                navigableMoveController.Navigator.SetRoute(route.Destinations);

            };

            _enemies.Add(enemyController);

        }

        private void ReturnToPool(ISpawnableObject spawnableObject)
        {

            if (!_poolService.TryDestroy(spawnableObject))
            {

                Debug.LogError(ErrorMessages.SpawnableObjectDestroy(spawnableObject.Gameobject.name));

                return;

            };

            _enemies.Remove(spawnableObject as EnemyController);

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {
            
            CurrentCooldown = Mathf.Clamp(CurrentCooldown - deltaTime, 0, Cooldown);

            if(CurrentCooldown == 0)
            {

                SetRandomSpawner();

                CreateFromPool(_currentSpawner);

                CurrentCooldown = Cooldown;

            };

            CheckoutSpawnableObjects(deltaTime);

        }

        #endregion

    }

}