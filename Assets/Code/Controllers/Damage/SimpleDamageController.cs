using UnityEngine;
using Constants;
using Controllers.Audio;
using Controllers.Services;
using Interfaces;
using Interfaces.Events;

namespace Controllers.Damage
{
    public class SimpleDamageController : IController, IUpdate, IDamageController
    {
        #region Fields

        private GameObject _gameObject;
        private int _damage;
        private HealthServiceController _healthServiceController;
        private AudioTrigger _damageAudioTrigger;
        private IOverlapper _damageOverlapper;

        #endregion

        #region Properties

        public AudioTrigger DamageAudioTrigger => _damageAudioTrigger;
        public GameObject GameObject => _gameObject;
        public int Damage => _damage;

        #endregion

        #region Constructors

        public SimpleDamageController(GameObject gameObject, int damage, string damageSoundConfiguration, HealthServiceController healthServiceController, IOverlapper damageOverlapper)
        {
            _gameObject                 = gameObject;
            _damageOverlapper           = damageOverlapper;
            _damage                     = damage;
            _healthServiceController    = healthServiceController;
            _damageAudioTrigger         = new AudioTrigger(damageSoundConfiguration, AudioTypes.SOUND);
        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {
            if (!_gameObject.activeSelf) return;

            var enemies = _damageOverlapper.Overlap();

            if (enemies.Count > 0)
            {
                _healthServiceController.Damage(enemies, _damage);

                _damageAudioTrigger.Play();

                _gameObject.SetActive(false);
            };
        }

        #endregion
    }
}