using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Models.Constructables
{
    public class ShooterModel
    {

        #region Properties

        public ISpawner Spawner { get; set; }
        public List<Transform> ShootingPoints { get; set; }
        public float Cooldown { get; set; }
        
        #endregion

    }

}
