using System.Linq;
using UnityEngine;
using Controllers.Services;
using Interfaces;
using Interfaces.Events;

namespace Controllers.Damage
{
    public class SimpleDamageController : IController, IUpdate, IDamageController
    {

        #region Fields

        private GameObject _gameObject;
        private BoxCollider2D _gameObjectCollider;
        private int _damage;
        private LayerMask _damageLayerMask;
        private HealthServiceController _healthServiceController;

        #endregion

        #region Properties

        public GameObject GameObject => _gameObject;
        public int Damage => _damage;

        #endregion

        #region Constructors

        public SimpleDamageController(GameObject gameObject, int damage, LayerMask damageLayerMask, HealthServiceController healthServiceController)
        {

            _gameObject                 = gameObject;
            _gameObjectCollider         = gameObject.GetComponent<BoxCollider2D>();
            _damage                     = damage;
            _damageLayerMask            = damageLayerMask;
            _healthServiceController    = healthServiceController;

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            if (!_gameObject.activeSelf) return;

            var enemies =
                Physics2D
                    .OverlapBoxAll(_gameObject.transform.position, _gameObjectCollider.size, _gameObject.transform.rotation.z, _damageLayerMask)
                    .ToList()
                    .Select(x => x.gameObject)
                    .ToList();

            if (enemies.Count > 0)
            {

                _healthServiceController.Damage(enemies, _damage);

                _gameObject.SetActive(false);

            };

        }

        #endregion

    }

}