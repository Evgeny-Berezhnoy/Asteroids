using UnityEngine;
using Constants;
using Interfaces;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Game/UI/User Interface configuration")]
    public class UserInterfaceConfiguration : ScriptableObject, IPrefabData, IInitialize
    {

        #region Fields

        private GameObject _playScreen;
        private GameObject _gameOverScreen;

        public string PlayScreenDirectory;
        public string GameOverScreenDirectory;

        #endregion

        #region Properties

        public GameObject Points => ModelsInitializer.GetObject(ref _playScreen, PlayScreenDirectory);
        public GameObject GameOverScreen => ModelsInitializer.GetObject(ref _gameOverScreen, GameOverScreenDirectory);

        #endregion

        #region Interfaces Properties

        public string GameobjectName => GameobjectNames.USER_INTERFACE;

        #endregion
        
        #region Interfaces Methods

        public void Initialize()
        {

            ModelsInitializer.InitializeObject(ref _playScreen, PlayScreenDirectory);
            ModelsInitializer.InitializeObject(ref _gameOverScreen, GameOverScreenDirectory);
            
        }

        #endregion

    }

}