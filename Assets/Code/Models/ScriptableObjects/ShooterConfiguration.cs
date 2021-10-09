using UnityEngine;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Configurations/Shooters/Instance")]
    public class ShooterConfiguration : ScriptableObject
    {

        #region Fields

        public string Name;
        public float Cooldown;
        public string ShooterMapDirectory;
        public string ProjectileDirectory;

        #endregion

    }

}