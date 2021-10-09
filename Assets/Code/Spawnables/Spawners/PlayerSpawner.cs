using UnityEngine;
using Constants;
using Controllers;
using Controllers.Services;
using ExtensionCompilation;
using Interfaces;
using Models.Constructables.ConfigurationModels;
using Spawnables.Spawners.Templates;

namespace Spawnables.Spawners
{
    public class PlayerSpawner : Spawner<PlayerConfigurationModel>
    {

        #region Fields

        private HealthServiceController _healthServiceController;

        #endregion

        #region Constructors

        public PlayerSpawner(IPrefabData prefab, HealthServiceController healthServiceController) : base(prefab, prefab.GameobjectName)
        {

            _healthServiceController = healthServiceController;

        }

        #endregion

        #region Interfaces Methods

        public override ISpawnableObject Spawn()
        {

            GameObject gameObject = new GameObject(_prefabName);

            gameObject
                .AddSpriteRendererAbsent(_prefab.Sprite, OrdersInLayers.PLAYER)
                .AddCircleCollider2DAbsent();

            gameObject.layer = Layers.PLAYER;

            PlayerController playerController = new PlayerController(gameObject, _prefab.HP, _prefab.Speed);

            _healthServiceController.Insert(gameObject, playerController.HealthController);

            return playerController;

        }

        #endregion

    }

}