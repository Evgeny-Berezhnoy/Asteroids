using UnityEngine;
using Interfaces;
using Views.Components;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game/Shooter configuration")]
    public class ShooterConfiguration : ScriptableObject, IPrefabData, IInitialize
    {

        #region Fields

        private GameObject _shooterMapPrefab;
        private ProjectileConfiguration _projectile;

        public string Name;
        public float Cooldown;
        public string ShooterMapDirectory;
        public string ProjectileDirectory;
        
        #endregion

        #region Properties

        public ShooterMap ShooterMap => ModelsInitializer.GetObject(ref _shooterMapPrefab, ShooterMapDirectory).GetComponent<ShooterMap>();
        public ProjectileConfiguration Projectile => ModelsInitializer.GetObject(ref _projectile, ProjectileDirectory);

        #endregion

        #region Interfaces Properties

        public string GameobjectName => Name;

        #endregion

        #region Interfaces Methods

        public void Initialize()
        {

            ModelsInitializer.InitializeObject(ref _projectile, ProjectileDirectory);
            ModelsInitializer.InitializeObject(ref _shooterMapPrefab, ShooterMapDirectory);

        }

        #endregion

    }

}
