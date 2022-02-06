using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Configurations/Enemies/Instance")]
    public class EnemyConfiguration : ScriptableObject
    {
        #region Fields

        public string Name;
        public string SpriteDirectory;
        public string ShooterConfigurationDirectory;
        public int HP;
        public int PointsForKill;
        public float Speed;

        #endregion
    }
}