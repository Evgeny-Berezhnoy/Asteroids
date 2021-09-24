using UnityEngine;
using Constants;
using Interfaces;
using Views.Components;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Game/Player configuration")]
    public class PlayerConfiguration : ScriptableObject, IPrefabData, IInitialize
    {

        #region Fields

        private Sprite _sprite;
        private ShooterMap _shooterMap;

        public string SpriteDirectory;
        public string ShooterMapDirectory;

        #endregion

        #region Properties

        public Sprite Sprite => ModelsInitializer.GetObject(ref _sprite, SpriteDirectory);
        public ShooterMap ShooterMap => ModelsInitializer.GetObject(ref _shooterMap, ShooterMapDirectory);

        #endregion

        #region Interfaces Properties

        public string GameobjectName => GameobjectNames.PLAYER;
        
        #endregion

        #region Fields

        public float Speed;
        public int HP;

        #endregion

        #region Interfaces Methods

        public void Initialize()
        {

            ModelsInitializer.InitializeObject(ref _sprite, SpriteDirectory);
            ModelsInitializer.InitializeObject(ref _shooterMap, ShooterMapDirectory);

        }

        #endregion

    }

}