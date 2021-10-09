using UnityEngine;
using Constants;
using Interfaces;
using Models;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{
    public class PlayerConfigurationModel : ConfigurationModel, IPrefabData
    {

        #region Fields

        public float Speed;
        public int HP;
        
        public Sprite Sprite;

        #endregion

        #region Interfaces Properties

        public string GameobjectName => GameobjectNames.PLAYER;

        #endregion

        #region Constructors

        public PlayerConfigurationModel(string configurationDirectory) : base(configurationDirectory)
        {

            var playerConfiguration = ModelsInitializer.LoadObject<PlayerConfiguration>(configurationDirectory);

            Speed   = playerConfiguration.Speed;
            HP      = playerConfiguration.HP;

            ModelsInitializer.InitializeObject(ref Sprite, playerConfiguration.SpriteDirectory);

        }

        #endregion

    }

}
