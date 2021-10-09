using UnityEngine;
using Controllers;
using Controllers.Damage;
using Controllers.Damage.Overlap;
using Controllers.Move;
using Controllers.Services;
using ExtensionCompilation;
using Interfaces;
using Models.Constructables.ConfigurationModels;
using Spawnables.Spawners.Templates;

namespace Spawnables.Spawners
{
    public class ProjectileSpawner : Spawner<ProjectileConfigurationModel>
    {

        #region Fields

        private LayerMask _damageLayerMask;
        private HealthServiceController _healthServiceController;
        private AudioServiceController _audioServiceController;
        
        #endregion

        #region Constructors

        public ProjectileSpawner(IPrefabData prefab, string prefabName, LayerMask damageLayerMask, HealthServiceController healthServiceController, AudioServiceController audioServiceController) : base(prefab, prefabName)
        {

            _damageLayerMask            = damageLayerMask;
            _healthServiceController    = healthServiceController;
            _audioServiceController     = audioServiceController;

        }

        #endregion

        #region Interfaces Methods

        public override ISpawnableObject Spawn()
        {

            var gameObject = new GameObject(_prefabName);

            gameObject.AddSpriteRendererAbsent(_prefab.Sprite);

            IOverlapper damageOverlapper;

            if (_prefab.IsRound)
            {

                damageOverlapper = new DamageCircleOverlapper(gameObject.transform, gameObject.GetComponentAbsent<CircleCollider2D>(), _damageLayerMask);

            }
            else
            {

                damageOverlapper = new DamageBoxOverlapper(gameObject.transform, gameObject.GetComponentAbsent<BoxCollider2D>(), _damageLayerMask);

            };

            var damageController = new SimpleDamageController(gameObject, _prefab.Damage, _prefab.HitAudioConfigurationDirectory, _healthServiceController, damageOverlapper);

            var projectileController =
                new ProjectileController(
                    gameObject,
                    new MoveController(gameObject.transform, _prefab.Speed),
                    damageController,
                    _prefab.LaunchAudioConfigurationDirectory,
                    _prefab.LifeTime);

            projectileController.LaunchAudioTrigger.AddHandler(_audioServiceController.Play);
            damageController.DamageAudioTrigger.AddHandler(_audioServiceController.Play);
            
            return projectileController;

        }

        #endregion

    }

}