using System;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Interfaces;
using Interfaces.Events;
using Models.ScriptableObjects;
using Spawnables.Services;
using Spawnables.Spawners;

namespace Controllers.Services
{
    public class PlayerServiceController : IController, IUpdate, IPoolServiceController, IGameStatementListener
    {

        #region Events

        public event Action OnPlayersDeath;

        #endregion

        #region Fields

        private PoolService _poolService;
        private Transform _playerTransform;
        private PlayerSpawner _spawner;
        private GameStateController _gameStateController;
        private PlayerController _playerController;
        
        #endregion

        #region Properties

        public PlayerController PlayerController => _playerController;
        
        #endregion

        #region Interfaces Properties

        public PoolService PoolService => _poolService;
        
        #endregion

        #region Constructors

        public PlayerServiceController(Transform playerTransform, PlayerConfiguration playerConfiguration, PoolService poolService, HealthServiceController healthServiceController, GameStateController gameStateController)
        {

            _poolService            = poolService;
            _playerTransform        = playerTransform;
            _spawner                = new PlayerSpawner(playerConfiguration, healthServiceController);
            _gameStateController    = gameStateController;
            
            poolService.CreatePool(_spawner);

            CreateFromPool();

        }

        #endregion

        #region Destructors

        ~PlayerServiceController()
        {

            var onPlayersDeathInvocationList = OnPlayersDeath.GetInvocationList();

            for(int i = 0; i < onPlayersDeathInvocationList.Length; i++)
            {

                OnPlayersDeath -= onPlayersDeathInvocationList[i] as Action;

            };

        }

        #endregion

        #region Methods

        private void CreateFromPool()
        {

            if (!_poolService.TryInstantiate(_spawner.PrefabName, out var spawnableObject))
            {

                Debug.LogError(ErrorMessages.SpawnableObjectCreate(_spawner.PrefabName));

                return;

            }

            _playerController = spawnableObject as PlayerController;

            _playerController.HealthController.Resurect();
            
        }

        private void ReturnToPool()
        {

            if (!_poolService.TryDestroy(_playerController))
            {

                Debug.LogError(ErrorMessages.SpawnableObjectDestroy(_playerController.Gameobject.name));

                return;

            };

            _playerController = null;

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            if (_gameStateController.GameIsStopped) return;

            if (_playerController.HealthController.IsDead)
            {

                OnPlayersDeath?.Invoke();

            };

        }

        public void StartGame()
        {

            if(_playerController == null)
            {

                CreateFromPool();

            }

            _playerController
                .Gameobject
                .transform
                .SetPositionAndRotation(_playerTransform);

        }

        public void StopGame()
        {

            ReturnToPool();

        }

        #endregion

    }

}