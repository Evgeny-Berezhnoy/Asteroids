using UnityEngine;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Configurations/Background")]
    public class BackgroundConfiguration : ScriptableObject
    {

        #region Fields

        public float Speed;
        public string SpriteDirectory;

        #endregion

    }

}