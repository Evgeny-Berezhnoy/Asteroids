using UnityEngine;
using Constants;
using Controllers;
using ExtensionCompilation;
using Interfaces;
using Models.Constructables.ConfigurationModels;
using Spawnables.Spawners.Templates;

namespace Spawnables.Spawners
{
    public class BackgroundSpawner : Spawner<BackgroundConfigurationModel>
    {

        #region Constructors

        public BackgroundSpawner(IPrefabData backgroundModel) : base(backgroundModel, backgroundModel.GameobjectName) { }

        #endregion

        #region Interfaces Methods

        public override ISpawnableObject Spawn()
        {

            GameObject gameObject = new GameObject(_prefabName);

            gameObject.transform.localScale = _prefab.SpriteScale;
            gameObject.layer = Layers.BACKGROUND;
            gameObject.AddSpriteRendererAbsent(_prefab.Sprite, OrdersInLayers.BACKGROUND);
            
            return new BackgroundController(gameObject, _prefab);

        }

        #endregion

    }

}