using UnityEngine;
using Controllers;
using Controllers.Damage;
using Controllers.Move;
using Controllers.Services;
using ExtensionCompilation;
using Interfaces;
using Models.ScriptableObjects;
using Spawnables.Spawners.Templates;

namespace Spawnables.Spawners
{
    public class ProjectileSpawner : Spawner<ProjectileConfiguration>
    {

        #region Fields

        private LayerMask _damageLayerMask;
        private HealthServiceController _healthServiceController;
        
        #endregion

        #region Constructors

        public ProjectileSpawner(ProjectileConfiguration prefab, string prefabName, LayerMask damageLayerMask, HealthServiceController healthServiceController) : base(prefab, prefabName)
        {

            _damageLayerMask            = damageLayerMask;
            _healthServiceController    = healthServiceController;

        }

        #endregion

        #region Interfaces Methods

        public override ISpawnableObject Spawn()
        {

            var gameObject = new GameObject(_prefabName);

            gameObject
                .AddSpriteRendererAbsent(_prefab.Sprite)
                .AddComponentAbsent<BoxCollider2D>();

            return
                new ProjectileController(
                    gameObject,
                    new MoveController(gameObject.transform, _prefab.Speed),
                    new SimpleDamageController(gameObject, _prefab.Damage, _damageLayerMask, _healthServiceController),
                    _prefab.LifeTime);

        }

        #endregion

    }

}