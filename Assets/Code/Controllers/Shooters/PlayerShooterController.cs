using System.Collections.Generic;
using UnityEngine;
using Controllers.Services;
using Interfaces;
using Interfaces.Events;
using Models.Constructables;
using Spawnables.Services;

namespace Controllers.Shooters
{
    public class PlayerShooterController : IController, IUpdate, IPoolServiceController, IGameStatementListener, ICooldown, IShoot
    {

        #region Fields

        private PoolService _poolService;
        private ProjectileServiceController _projectileServiceController;
        private GameStateController _gameStateController;
        private ISpawner _spawner;
        private List<Transform> _shootingPoints;
        
        #endregion

        #region Interfaces Properties

        public PoolService PoolService => _poolService;
        public float Cooldown { get; set; }
        public float CurrentCooldown { get; set; }
        
        #endregion

        #region Constructors

        public PlayerShooterController(PoolService poolService, ProjectileServiceController projectileServiceController, GameStateController gameStateController)
        {
            _poolService                    = poolService;
            _projectileServiceController    = projectileServiceController;
            _gameStateController            = gameStateController;
        }

        #endregion

        #region Methods

        public void SetShooterModel(ShooterModel shooterModel)
        {
            _spawner        = shooterModel.Spawner;
            _shootingPoints = shooterModel.ShootingPoints;

            Cooldown        = shooterModel.Cooldown;
            CurrentCooldown = 0;   
        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {
            if (_gameStateController.GameIsStopped) return;

            CurrentCooldown = Mathf.Clamp(CurrentCooldown - deltaTime, 0, Cooldown);
        }

        public void Shoot()
        {
            if (CurrentCooldown > 0) return;

            _projectileServiceController.CreateFromPool(_spawner, _shootingPoints);

            CurrentCooldown = Cooldown;
        }

        public void StartGame() => CurrentCooldown = 0;
        public void StopGame(){}

        #endregion

    }

}