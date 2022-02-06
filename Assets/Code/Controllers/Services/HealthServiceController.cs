using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Controllers.Services
{
    public class HealthServiceController
    {
        #region Fields

        private Dictionary<GameObject, IHealthController> _healthDictionary;

        #endregion

        #region Constructors

        public HealthServiceController()
        {
            _healthDictionary = new Dictionary<GameObject, IHealthController>();
        }

        #endregion

        #region Methods

        public void Insert(GameObject gameObject, IHealthController healthController)
        {
            if (!_healthDictionary.ContainsKey(gameObject))
            {
                _healthDictionary.Add(gameObject, healthController);
            }
            else
            {
                _healthDictionary[gameObject] = healthController;
            };
        }

        public void Remove(GameObject gameObject)
        {
            if (!_healthDictionary.ContainsKey(gameObject)) return;

            _healthDictionary.Remove(gameObject);
        }
        
        public void Clear() => _healthDictionary.Clear();

        public void Damage(GameObject gameObject, int damage)
        {
            if (_healthDictionary.TryGetValue(gameObject, out var healthController))
            {
                healthController.Damage(damage);
            };
        }

        public void Damage(List<GameObject> gameObjects, int damage)
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                Damage(gameObjects[i], damage);   
            };
        }

        public void Heal(GameObject gameObject, int health)
        {
            if (_healthDictionary.TryGetValue(gameObject, out var healthController))
            {
                healthController.Heal(health);
            };   
        }

        public void Resurect(GameObject gameObject)
        {
            if (_healthDictionary.TryGetValue(gameObject, out var healthController))
            {
                healthController.Resurect();
            };
        }

        public void Resurect(List<GameObject> gameObjects)
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                Resurect(gameObjects[i]);
            };
        }

        #endregion
    }
}