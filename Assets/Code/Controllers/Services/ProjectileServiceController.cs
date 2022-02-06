using System.Collections.Generic;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Interfaces;
using Interfaces.Events;
using Spawnables.Services;

namespace Controllers.Services
{
    public class ProjectileServiceController : IController, IUpdate, IPoolManagerController, IGameStatementListener
    {
        
        #region Fields

        private PoolService _poolService;
        private List<ISpawnableObject> _projectiles = new List<ISpawnableObject>();
        private GameStateController _gameStateController;

        #endregion

        #region Interfaces Properties

        public PoolService PoolService => _poolService;
        
        #endregion

        #region Constructors

        public ProjectileServiceController(PoolService poolService, GameStateController gameStateController)
        {
            _poolService            = poolService;
            _gameStateController    = gameStateController;
        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {
            for (int i = _projectiles.Count - 1; i >= 0; i--)
            {
                var projectile = _projectiles[i];

                if (!projectile.Gameobject.activeSelf)
                {
                    ReturnToPool(projectile);

                    continue;
                };

                if (projectile is IUpdate updateController)
                {
                    updateController.OnUpdate(deltaTime);
                };
            };
        }

        public void CreateFromPool(ISpawner spawner, List<Transform> spawnPoints)
        {
            if (_gameStateController.GameIsStopped) return;

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                var shootTransform = spawnPoints[i];

                if (!_poolService.TryInstantiate(spawner.PrefabName, out var projectile))
                {
                    Debug.LogError(ErrorMessages.SpawnableObjectCreate(spawner.PrefabName));

                    return;
                }

                projectile
                    .Gameobject
                    .transform
                    .SetPositionAndRotation(shootTransform);

                var projectileController = projectile as ProjectileController;

                projectileController.CurrentLifeTime = projectileController.LifeTime;

                projectileController.LaunchAudioTrigger.Play();

                _projectiles.Add(projectile);
            };
        }
        
        public void ReturnToPool(ISpawnableObject spawnableObject)
        {
            if (!_poolService.TryDestroy(spawnableObject))
            {
                Debug.LogError(ErrorMessages.SpawnableObjectDestroy(spawnableObject.Gameobject.name));

                return;
            };

            _projectiles.Remove(spawnableObject);
        }

        public void StartGame()
        {
            for (int i = _projectiles.Count - 1; i >= 0; i--)
            {
                var projectile = _projectiles[i];

                projectile.Gameobject.SetActive(false);
                
                ReturnToPool(projectile);
            };
        }

        public void StopGame(){}

        #endregion
    }
}