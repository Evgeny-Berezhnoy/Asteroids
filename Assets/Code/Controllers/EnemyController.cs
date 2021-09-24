using UnityEngine;
using Constants;
using Controllers.Health;
using Controllers.Move;
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
        private int _pointsForKill;
        private PointsController _pointsController;
        
        #endregion

        #region Properties

        public IMovable MoveController { get; set; }
        public IHealthController HealthController { get; set; }
        
        #endregion

        #region Interfaces properties

        public GameObject Gameobject { get => _gameObject; }

        #endregion

        #region Constructors

        public EnemyController(GameObject gameObject, EnemyConfiguration enemyConfiguration, EnemyShooterController enemyShooterController, PointsController pointsController)
        {

            _gameObject         = gameObject;
            _shooterController  = enemyShooterController;
            _pointsForKill      = enemyConfiguration.PointsForKill;
            _pointsController   = pointsController;
            
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

                Debug.Log(DebugLogMessages.EnemyDied(_gameObject));

                _pointsController.AddPoints(_pointsForKill);

                _gameObject.SetActive(false);

            };

        }
        
        #endregion

    }

}