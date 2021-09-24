using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Models.ScriptableObjects
{
    
    [CreateAssetMenu(menuName = "Game/Enemies storage")]
    public class EnemiesStorage : ScriptableObject, IInitialize
    {

        #region Fields

        private List<EnemyConfiguration> _enemies;

        public float SpawnCooldown;
        public List<string> EnemyConfigurationsDirectories;

        #endregion

        #region Properties

        public List<EnemyConfiguration> Enemies => _enemies;

        #endregion

        #region Interfaces Methods

        public void Initialize()
        {

            _enemies = new List<EnemyConfiguration>();

            for (int i = 0; i < EnemyConfigurationsDirectories.Count; i++)
            {

                EnemyConfiguration enemyConfiguration = null;

                ModelsInitializer.InitializeObject(ref enemyConfiguration, EnemyConfigurationsDirectories[i]);

                _enemies.Add(enemyConfiguration);

            };

        }

        #endregion

    }

}