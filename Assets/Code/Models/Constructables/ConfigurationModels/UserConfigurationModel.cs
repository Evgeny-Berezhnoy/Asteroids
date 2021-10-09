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

            var userInterfaceConfiguration = ModelsInitializer.LoadObject<UserInterfaceConfiguration>(configurationDirectory);

            ModelsInitializer.InitializeObject(ref PlayScreen, userInterfaceConfiguration.PlayScreenDirectory);
            ModelsInitializer.InitializeObject(ref GameOverScreen, userInterfaceConfiguration.GameOverScreenDirectory);

        }

        #endregion

    }

}