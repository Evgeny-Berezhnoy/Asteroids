using System.Collections.Generic;
using UnityEngine;
using Controllers.Services;
using Interfaces;
using Interfaces.Events;
using Models.Constructables;
using Spawnables.Services;

namespace Controllers.Shooters
{
    public class PlayerShooterController : IController, IUpdate, IPoolServiceController , ICooldown, IShoot
    {

        #region Fields

        private PoolService _poolService;
        private ISpawner _spawner;
        private List<Transform> _shootingPoints;
        private ProjectileServiceController _projectileServiceController;

        #endregion

        #region Interfaces Properties

        public PoolService PoolService => _poolService;
        public float Cooldown { get; set; }
        public float CurrentCooldown { get; set; }

        #endregion

        #region Constructors

        public PlayerShooterController(PoolService poolService, ProjectileServiceController projectileServiceController)
        {

            _poolService                    = poolService;
            _projectileServiceController    = projectileServiceController;
            
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

            CurrentCooldown = Mathf.Clamp(CurrentCooldown - deltaTime, 0, Cooldown);

        }

        public void Shoot()
        {

            if (CurrentCooldown > 0) return;

            _projectileServiceController.CreateFromPool(_spawner, _shootingPoints);

            CurrentCooldown = Cooldown;

        }

        #endregion

    }

}