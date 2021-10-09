using System.Collections.Generic;
using UnityEngine;

namespace Models.ScriptableObjects
{
    
    [CreateAssetMenu(menuName = "Configurations/Enemies/Storage")]
    public class EnemiesStorage : ScriptableObject
    {

        #region Fields

        public float SpawnCooldown;
        public List<string> EnemyConfigurations;

        #endregion

    }

}