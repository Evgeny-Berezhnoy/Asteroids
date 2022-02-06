using UnityEngine;
using Controllers.Health;
using Controllers.Move;
using Interfaces;

namespace Controllers
{
    public class PlayerController : ISpawnableObject
    {
        #region Fields

        private GameObject _gameObject;
        
        #endregion

        #region Interfaces Properties

        public GameObject Gameobject => _gameObject;
        public HealthController HealthController { get; set; }
        public IMovable MoveController { get; set; }

        #endregion

        #region Constructors

        public PlayerController(GameObject gameObject, int health, float speed)
        {
            _gameObject         = gameObject;

            HealthController    = new PlayerHealthController(health);
            MoveController      = new RestrictedMoveController(_gameObject.transform, speed);
        }

        #endregion
    }
}