using UnityEngine;
using Interfaces;
using Views.Components;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Game/Configuration")]
    public class GameConfiguration : ScriptableObject, IInitialize
    {

        #region Fields

        private ShootersStorage _shootersStorage;
        private EnemiesStorage _enemiesStorage;
        private PlayerConfiguration _playerConfiguration;
        private UserInterfaceConfiguration _userInterfaceConfiguration;
        private GameObject _screenMapPrefab;

        public string ShootersStorageDirectory;
        public string EnemiesStorageDirectory;
        public string PlayerConfigurationDirectory;
        public string UserInterfaceConfigurationDirectory;
        public string ScreenMapPrefabDirectory;

        #endregion

        #region Properties

        public ShootersStorage ShootersStorage                          => ModelsInitializer.GetObject(ref _shootersStorage, ShootersStorageDirectory);
        public EnemiesStorage EnemiesStorage                            => ModelsInitializer.GetObject(ref _enemiesStorage, EnemiesStorageDirectory);
        public PlayerConfiguration PlayerConfiguration                  => ModelsInitializer.GetObject(ref _playerConfiguration, PlayerConfigurationDirectory);
        public UserInterfaceConfiguration UserInterfaceConfiguration    => ModelsInitializer.GetObject(ref _userInterfaceConfiguration, UserInterfaceConfigurationDirectory);
        public ScreenMap ScreenMapPrefab                                => ModelsInitializer.GetObject(ref _screenMapPrefab, ScreenMapPrefabDirectory).GetComponent<ScreenMap>();
        
        #endregion

        #region Methods

        public void Initialize()
        {

            ModelsInitializer.InitializeObject(ref _shootersStorage, ShootersStorageDirectory);
            ModelsInitializer.InitializeObject(ref _enemiesStorage, EnemiesStorageDirectory);
            ModelsInitializer.InitializeObject(ref _playerConfiguration, PlayerConfigurationDirectory);
            ModelsInitializer.InitializeObject(ref _userInterfaceConfiguration, UserInterfaceConfigurationDirectory);
            ModelsInitializer.InitializeObject(ref _screenMapPrefab, ScreenMapPrefabDirectory);
            
        }

        #endregion

    }

}