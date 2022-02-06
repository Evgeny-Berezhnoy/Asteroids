using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Configurations/Projectile")]
    public class ProjectileConfiguration : ScriptableObject
    {
        #region Fields

        public string Name;
        public string SpriteDirectory;
        public bool IsRound;
        public int Damage;
        public float Speed;
        public float LifeTime;

        public string LaunchAudioConfigurationDirectory;
        public string HitAudioConfigurationDirectory;

        #endregion
    }
}