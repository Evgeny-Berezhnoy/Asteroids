using UnityEngine;
using Controllers.Health;
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
        public MoveController MoveController { get; set; }

        #endregion

        #region Constructors

        public PlayerController(GameObject gameObject, int health, float speed)
        {

            _gameObject         = gameObject;

            HealthController    = new PlayerHealthController(health);
            MoveController      = new MoveController(_gameObject.transform, speed);

        }

        #endregion

    }

}
