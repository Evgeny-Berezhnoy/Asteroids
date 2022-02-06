using System.Collections.Generic;
using UnityEngine;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{
    public class GameConfigurationModel : ConfigurationModel
    {
        #region Fields

        public float EnemiesSpawnCooldown;
        public ScreenMapConfigurationModel ScreenMap;
        public PlayerConfigurationModel Player;
        public BackgroundConfigurationModel Background;
        public UserInterfaceConfigurationModel UserInterface;
        public AudioConfigurationModel Audio;
        public List<ShooterConfigurationModel> Shooters = new List<ShooterConfigurationModel>();
        public List<EnemyConfigurationModel> Enemies    = new List<EnemyConfigurationModel>();
        
        #endregion

        #region Constructors

        public GameConfigurationModel(string configurationDirectory, Transform rootTransform) : base(configurationDirectory)
        {
            var gameConfiguration = ResourcesLoader.LoadObject<GameConfiguration>(configurationDirectory);

            ScreenMap       = new ScreenMapConfigurationModel(gameConfiguration.ScreenMapPrefabDirectory, rootTransform);
            Player          = new PlayerConfigurationModel(gameConfiguration.PlayerConfigurationDirectory);
            Background      = new BackgroundConfigurationModel(gameConfiguration.BackgroundConfigurationDirectory, rootTransform);
            UserInterface   = new UserInterfaceConfigurationModel(gameConfiguration.UserInterfaceConfigurationDirectory);
            Audio           = new AudioConfigurationModel(gameConfiguration.AudioStorageDirectory);
            
            CreateShooters(gameConfiguration.ShootersStorageDirectory);
            CreateEnemies(gameConfiguration.EnemiesStorageDirectory);
        }

        #endregion

        #region Methods

        private void CreateShooters(string configurationDirectory)
        {
            var shootersStorage = ResourcesLoader.LoadObject<ShootersStorage>(configurationDirectory);

            for (int i = 0; i < shootersStorage.Configurations.Count; i++)
            {
                Shooters.Add(new ShooterConfigurationModel(shootersStorage.Configurations[i]));
            };
        }

        private void CreateEnemies(string configurationDirectory)
        {
            EnemiesStorage enemiesStorage = ResourcesLoader.LoadObject<EnemiesStorage>(configurationDirectory);

            EnemiesSpawnCooldown = enemiesStorage.SpawnCooldown;

            for (int i = 0; i < enemiesStorage.EnemyConfigurations.Count; i++)
            {
                Enemies.Add(new EnemyConfigurationModel(enemiesStorage.EnemyConfigurations[i]));
            };
        }

        #endregion
    }
}