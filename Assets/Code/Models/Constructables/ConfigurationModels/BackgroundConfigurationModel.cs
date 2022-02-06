using System.Collections.Generic;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Interfaces;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{
    public class BackgroundConfigurationModel : ConfigurationModel, IPrefabData
    {
        #region Fields

        public float Speed;
        public Sprite Sprite;
        public Vector3 SpriteScale;
        public LinkedList<Transform> SpawnTransforms = new LinkedList<Transform>();

        #endregion

        #region Interfaces Properties

        public string GameobjectName => GameobjectNames.BACKGROUND;

        #endregion

        #region Constructors

        public BackgroundConfigurationModel(string configurationDirectory, Transform rootTransform) : base(configurationDirectory)
        {
            var backgroundConfiguration = ResourcesLoader.LoadObject<BackgroundConfiguration>(configurationDirectory);

            Speed = backgroundConfiguration.Speed;

            ResourcesLoader.InitializeObject(ref Sprite, backgroundConfiguration.SpriteDirectory);

            CreateSpawnTransforms(rootTransform);
        }

        #endregion

        #region Methods

        private void CreateSpawnTransforms(Transform rootTransform)
        {
            var camera = Camera.main;

            float cameraWidth = 2 * camera.orthographicSize * camera.aspect;
            float widthRatio = cameraWidth / Sprite.bounds.size.x;

            SpriteScale = Vector3.one * widthRatio;

            var backgroundMapModelTransform = new GameObject(GameobjectNames.BACKGROUND_MAP).transform;

            backgroundMapModelTransform.SetParent(rootTransform);
            backgroundMapModelTransform.SetLocalPositionAndRotation();

            var spawnPoinsAmount = (int)(2 * camera.orthographicSize / Sprite.bounds.size.y);

            spawnPoinsAmount = ((spawnPoinsAmount % 2) == 1 ? spawnPoinsAmount : spawnPoinsAmount + 1) + 2;

            for(int i = -spawnPoinsAmount / 2; i <= spawnPoinsAmount / 2; i++)
            {
                var spawnPointPosition  = new Vector2(backgroundMapModelTransform.position.x, backgroundMapModelTransform.position.y + (i * Sprite.bounds.size.y * widthRatio));

                var spawnPointTransform = new GameObject(GameobjectNames.BACKGROUND_SPAWN_POINT).transform;

                spawnPointTransform.SetParent(backgroundMapModelTransform);
                spawnPointTransform.position = spawnPointPosition;
                spawnPointTransform.localScale *= widthRatio;

                SpawnTransforms.AddFirst(spawnPointTransform);
            };
        }

        #endregion
    }
}