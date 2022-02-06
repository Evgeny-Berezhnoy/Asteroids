using UnityEngine;
using Constants;
using Controllers.Audio;
using Interfaces;
using Interfaces.Events;

namespace Controllers
{
    public class ProjectileController : ISpawnableObject, ILifeTime, IUpdate
    {

        #region Constants

        private readonly Vector3 _projectileDirectory = new Vector3(0, 1);

        #endregion

        #region Fields

        private GameObject _gameObject;
        private IMovable _moveController;
        private IDamageController _damageController;
        private AudioTrigger _launchAudioTrigger;

        #endregion

        #region Properties

        public AudioTrigger LaunchAudioTrigger => _launchAudioTrigger;

        #endregion

        #region Interfaces properties

        public GameObject Gameobject => _gameObject;
        public float LifeTime { get; set; }
        public float CurrentLifeTime { get; set; }
        public bool IsAlive => CurrentLifeTime > 0;

        #endregion

        #region Constructors

        public ProjectileController(GameObject gameObject, IMovable moveController, IDamageController damageController, string LaunchAudioConfigurationDirectory, float lifeTime = 0)
        {
            _gameObject         = gameObject;
            _moveController     = moveController;
            _damageController   = damageController;
            _launchAudioTrigger = new AudioTrigger(LaunchAudioConfigurationDirectory, AudioTypes.SOUND);

            LifeTime        = lifeTime;
            CurrentLifeTime = lifeTime;   
        }

        #endregion

        #region Methods

        private bool CheckLifeTime(float deltaTime)
        {
            CurrentLifeTime -= deltaTime;

            if (!IsAlive)
            {
                CurrentLifeTime = 0;

                _gameObject.SetActive(false);
            };

            return _gameObject.activeSelf;
        }

        #endregion

        #region Interface methods

        public void OnUpdate(float deltaTime)
        {
            if (!_gameObject.activeSelf) return;
            if (!CheckLifeTime(deltaTime)) return;
            
            _moveController.Move(Quaternion.Euler(_gameObject.transform.rotation.x, _gameObject.transform.rotation.y, _gameObject.transform.rotation.z) * _projectileDirectory, deltaTime);
            
            if (_damageController is IUpdate updateDamageController)
            {
                updateDamageController.OnUpdate(deltaTime);
            };
        }

        #endregion
    }
}