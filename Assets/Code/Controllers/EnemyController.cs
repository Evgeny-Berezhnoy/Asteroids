using UnityEngine;
using Controllers.Health;
using Controllers.Shooters;
using Interfaces;
using Interfaces.Events;
using Models.ScriptableObjects;

namespace Controllers
{
    public class EnemyController : ISpawnableObject, IUpdate
    {

        #region Fields

        private GameObject _gameObject;
        private EnemyShooterController _shooterController;
        
        #endregion

        #region Properties

        public IMovable MoveController { get; set; }
        public IHealthController HealthController { get; set; }
        
        #endregion

        #region Interfaces properties

        public GameObject Gameobject { get => _gameObject; }

        #endregion

        #region Constructors

        public EnemyController(GameObject gameObject, EnemyConfiguration enemyConfiguration, EnemyShooterController enemyShooterController)
        {

            _gameObject         = gameObject;
            _shooterController  = enemyShooterController;

            MoveController      = new EnemyMoveController(_gameObject.transform, enemyConfiguration.Speed, new NavigatorController(_gameObject.transform));
            HealthController    = new EnemyHealthController(enemyConfiguration.HP);

        }

        #endregion

        #region Interface methods

        public void OnUpdate(float deltaTime)
        {

            if (!_gameObject.activeSelf) return;

            if(MoveController is IUpdate updateMoveController)
            {

                updateMoveController.OnUpdate(deltaTime);

            }

            if(MoveController is INavigable navigableController)
            {

                if (navigableController.Navigator.Arrived)
                {

                    _gameObject.SetActive(false);

                };

            }

            _shooterController.OnUpdate(deltaTime);

            if (HealthController.IsDead)
            {

                _gameObject.SetActive(false);

            };

        }
        
        #endregion

    }

}