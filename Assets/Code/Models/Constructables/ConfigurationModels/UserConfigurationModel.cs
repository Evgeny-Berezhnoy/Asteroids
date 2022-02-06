using UnityEngine;
using Constants;
using Interfaces;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{
    public class UserInterfaceConfigurationModel : ConfigurationModel, IPrefabData
    {
        #region Fields

        public GameObject PlayScreen;
        public GameObject GameOverScreen;

        #endregion

        #region Interfaces Properties

        public string GameobjectName => GameobjectNames.USER_INTERFACE;

        #endregion

        #region Constructors

        public UserInterfaceConfigurationModel(string configurationDirectory) : base(configurationDirectory)
        {
            var userInterfaceConfiguration = ResourcesLoader.LoadObject<UserInterfaceConfiguration>(configurationDirectory);

            ResourcesLoader.InitializeObject(ref PlayScreen, userInterfaceConfiguration.PlayScreenDirectory);
            ResourcesLoader.InitializeObject(ref GameOverScreen, userInterfaceConfiguration.GameOverScreenDirectory);
        }

        #endregion
    }
}