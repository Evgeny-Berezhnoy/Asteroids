using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Game/Shooters storage")]
    public class ShootersStorage : ScriptableObject, IInitialize
    {

        #region Fields

        private List<ShooterConfiguration> _shooters;

        public List<string> ShootersConfigurationsDirectories;

        #endregion

        #region Properties

        public List<ShooterConfiguration> Shooters => _shooters;

        #endregion

        #region Interfaces Methods

        public void Initialize()
        {

            _shooters = new List<ShooterConfiguration>();

            for (int i = 0; i < ShootersConfigurationsDirectories.Count; i++)
            {

                ShooterConfiguration shooterConfiguration = null;

                ModelsInitializer.InitializeObject(ref shooterConfiguration, ShootersConfigurationsDirectories[i]);

                _shooters.Add(shooterConfiguration);

            };

        }

        #endregion

    }

}