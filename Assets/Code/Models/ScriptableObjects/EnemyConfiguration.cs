using UnityEngine;
using Interfaces;

namespace Models.ScriptableObjects
{
    
    [CreateAssetMenu(menuName = "Game/Enemy configuration")]
    public class EnemyConfiguration : ScriptableObject, IPrefabData, IInitialize
    {

        #region Fields

        private Sprite _sprite;
        private ShooterConfiguration _shooterConfiguration;

        public string SpriteDirectory;
        public string ShooterConfigurationDirectory;
        public string Name;
        public int HP;
        public int PointsForKill;
        public float Speed;
        
        #endregion

        #region Properties

        public Sprite Sprite => ModelsInitializer.GetObject(ref _sprite, SpriteDirectory);
        public ShooterConfiguration ShooterConfiguration => ModelsInitializer.GetObject(ref _shooterConfiguration, ShooterConfigurationDirectory);

        #endregion

        #region Interfaces Properties

        public string GameobjectName => Name;

        #endregion

        #region Interfaces Methods

        public void Initialize()
        {

            ModelsInitializer.InitializeObject(ref _sprite, SpriteDirectory);
            ModelsInitializer.InitializeObject(ref _shooterConfiguration, ShooterConfigurationDirectory);

        }

        #endregion

    }

}