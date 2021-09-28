using UnityEngine;
using Interfaces;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{
    public class EnemyConfigurationModel : ConfigurationModel, IPrefabData
    {

        #region Fields

        private string _name;
        
        public int HP;
        public int PointsForKill;
        public float Speed;
        
        public Sprite Sprite;
        public ShooterConfigurationModel Shooter;

        #endregion

        #region

        public string GameobjectName => _name;

        #endregion

        #region Constructors

        public EnemyConfigurationModel(string configurationDirectory) : base(configurationDirectory)
        {
            
            var enemyConfiguration  = ModelsInitializer.LoadObject<EnemyConfiguration>(configurationDirectory);

            _name                   = enemyConfiguration.Name;
            HP                      = enemyConfiguration.HP;
            PointsForKill           = enemyConfiguration.PointsForKill;
            Speed                   = enemyConfiguration.Speed;

            Sprite = ModelsInitializer.LoadObject<Sprite>(enemyConfiguration.SpriteDirectory);

            Shooter = new ShooterConfigurationModel(enemyConfiguration.ShooterConfigurationDirectory);

        }

        #endregion

    }

}