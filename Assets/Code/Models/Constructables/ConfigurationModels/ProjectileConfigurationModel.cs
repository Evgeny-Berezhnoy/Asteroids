using UnityEngine;
using Interfaces;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{

    public class ProjectileConfigurationModel : ConfigurationModel, IPrefabData
    {

        #region Fields

        private string _name;

        public int Damage;
        public float Speed;
        public float LifeTime;
        public bool IsRound;
        
        public string LaunchAudioConfigurationDirectory;
        public string HitAudioConfigurationDirectory;

        public Sprite Sprite;

        #endregion

        #region Interfaces Properties

        public string GameobjectName => _name;

        #endregion

        #region Constructors

        public ProjectileConfigurationModel(string configurationDirectory) : base(configurationDirectory)
        {

            var projectileConfiguration = ModelsInitializer.LoadObject<ProjectileConfiguration>(configurationDirectory);

            _name       = projectileConfiguration.Name;

            Damage      = projectileConfiguration.Damage;
            Speed       = projectileConfiguration.Speed;
            LifeTime    = projectileConfiguration.LifeTime;
            IsRound     = projectileConfiguration.IsRound;

            LaunchAudioConfigurationDirectory   = projectileConfiguration.LaunchAudioConfigurationDirectory;
            HitAudioConfigurationDirectory      = projectileConfiguration.HitAudioConfigurationDirectory;

            ModelsInitializer.InitializeObject(ref Sprite, projectileConfiguration.SpriteDirectory);

        }

        #endregion

    }

}