using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Constants;
using Controllers.Move;
using ExtensionCompilation;
using Interfaces;
using Interfaces.Events;
using Models.Constructables.ConfigurationModels;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Controllers.Services
{
    public class BackgroundServiceController : IController, IUpdate, IPoolServiceController
    {

        #region Fields

        private PoolService _poolService;
        private BackgroundSpawner _spawner;
        private LinkedList<Transform> _spawnPoints;
        private LinkedList<BackgroundController> _backgroundTiles = new LinkedList<BackgroundController>();

        #endregion

        #region Properties

        public PoolService PoolService => _poolService;
        
        #endregion

        #region Constructors

        public BackgroundServiceController(BackgroundConfigurationModel backgroundModel, PoolService poolService)
        {
            _spawner            = new BackgroundSpawner(backgroundModel);
            _poolService        = poolService;
            _spawnPoints        = backgroundModel.SpawnTransforms;

            poolService.CreatePool(_spawner);

            for (var spawnPoint = _spawnPoints.Last; spawnPoint != null;)
            {
                CreateFromPool(spawnPoint);

                spawnPoint = spawnPoint.Previous;
            };
        }

        #endregion

        #region Methods

        private void CreateFromPool() => CreateFromPool(_spawnPoints.First);
        
        private void CreateFromPool(LinkedListNode<Transform> spawnPointNode)
        {
            if (!_poolService.TryInstantiate(_spawner.PrefabName, out var spawnableObject))
            {
                Debug.LogError(ErrorMessages.SpawnableObjectCreate(_spawner.PrefabName));

                return;
            };

            var backgroundController = spawnableObject as BackgroundController;

            backgroundController
                .Gameobject
                .transform
                .SetPositionAndRotation(spawnPointNode.Value);

            if (_backgroundTiles.Count > 0)
            {
                var previousTileNavigator = (_backgroundTiles.First().MoveController as NavigableMoveController).Navigator as NavigatorController;

                previousTileNavigator.OnReachingPoint -= CreateFromPool;   
            };

            var currentNavigator = (backgroundController.MoveController as NavigableMoveController).Navigator as NavigatorController;

            currentNavigator.SetRoute(_spawnPoints, spawnPointNode);
            currentNavigator.OnReachingPoint += CreateFromPool;

            _backgroundTiles.AddFirst(backgroundController);
        }

        private void ReturnToPool(ISpawnableObject spawnableObject)
        {
            if (!_poolService.TryDestroy(spawnableObject))
            {
                Debug.LogError(ErrorMessages.SpawnableObjectDestroy(spawnableObject.Gameobject.name));

                return;
            };

            _backgroundTiles.Remove(spawnableObject as BackgroundController);
        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {
            for (var tileNode = _backgroundTiles.Last; tileNode != null; )
            {
                var backgroundTile = tileNode.Value;

                if (!backgroundTile.Gameobject.activeSelf)
                {
                    tileNode = tileNode.Previous;

                    ReturnToPool(tileNode.Next.Value);

                    continue;
                };

                backgroundTile.OnUpdate(deltaTime);

                tileNode = tileNode.Previous;
            };
        }

        #endregion
    }
}