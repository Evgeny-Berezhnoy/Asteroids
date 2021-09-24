using UnityEngine;
using Interfaces;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game/Projectile configuration")]
    public class ProjectileConfiguration : ScriptableObject, IPrefabData, IInitialize
    {

        #region Fields

        private Sprite _sprite;
        
        public string SpriteDirectory;
        public string Name;
        public float Speed;
        public int Damage;
        public float LifeTime;

        #endregion

        #region Properties

        public Sprite Sprite => ModelsInitializer.GetObject(ref _sprite, SpriteDirectory);
        
        #endregion

        #region Interfaces Properties

        public string GameobjectName => Name;

        #endregion

        #region Interfaces Methods

        public void Initialize()
        {

            ModelsInitializer.InitializeObject(ref _sprite, SpriteDirectory);
            
        }

        #endregion

    }

}