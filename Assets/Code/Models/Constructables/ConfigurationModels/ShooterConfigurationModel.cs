using UnityEngine;
using Interfaces;
using Models.Constructables.Templates;
using Models.ScriptableObjects;
using Views.Components;

namespace Models.Constructables.ConfigurationModels
{
    public class ShooterConfigurationModel : ConfigurationModel, IPrefabData
    {

        #region Fields

        [SerializeField] private string _name;

        public float Cooldown;

        public ShooterMap ShooterMap;
        public ProjectileConfigurationModel Projectile;

        #endregion

        #region Interfaces Properties

        public string GameobjectName => _name;

        #endregion

        #region Constructors

        public ShooterConfigurationModel(string configurationDirectory) : base(configurationDirectory)
        {

            var shooterConfiguration = ModelsInitializer.LoadObject<ShooterConfiguration>(configurationDirectory);

            _name       = shooterConfiguration.Name;
            
            Cooldown    = shooterConfiguration.Cooldown;

            ShooterMap  = ModelsInitializer.LoadObject<GameObject>(shooterConfiguration.ShooterMapDirectory).GetComponent<ShooterMap>();
            
            Projectile  = new ProjectileConfigurationModel(shooterConfiguration.ProjectileDirectory);

        }

        #endregion

    }

}
