using UnityEngine;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Configurations/Game")]
    public class GameConfiguration : ScriptableObject
    {

        #region Fields

        public string ShootersStorageDirectory;
        public string EnemiesStorageDirectory;
        public string PlayerConfigurationDirectory;
        public string BackgroundConfigurationDirectory;
        public string UserInterfaceConfigurationDirectory;
        public string AudioStorageDirectory;
        public string ScreenMapPrefabDirectory;

        #endregion

    }

}