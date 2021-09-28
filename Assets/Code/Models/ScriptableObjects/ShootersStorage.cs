using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Configurations/Shooters/Storage")]
    public class ShootersStorage : ScriptableObject, IConfigurationStorage
    {

        #region Fields

        [SerializeField] private List<string> _configurations;

        #endregion

        #region Interfaces Properties

        public List<string> Configurations => _configurations;
        
        #endregion

    }

}