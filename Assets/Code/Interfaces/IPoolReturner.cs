using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IPoolManagerController : IPoolServiceController
    {

        #region Methods

        void CreateFromPool(ISpawner spawner, List<Transform> spawnPoints);
        
        void ReturnToPool(ISpawnableObject spawnableObject);

        #endregion

    }

}
