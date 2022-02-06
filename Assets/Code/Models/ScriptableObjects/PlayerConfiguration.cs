using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Configurations/Player")]
    public class PlayerConfiguration : ScriptableObject
    {
        #region Fields

        public float Speed;
        public int HP;
        public string SpriteDirectory;
        
        #endregion
    }
}