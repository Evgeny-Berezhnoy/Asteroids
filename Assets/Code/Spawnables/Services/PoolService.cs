using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Spawnables.Pools;

namespace Spawnables.Services
{
    public class PoolService
    {
        #region Constants

        private const int StartCapacity = 8;

        #endregion

        #region Fields

        private Dictionary<string, PoolSpace> _pools;
        private Transform _rootTransform;

        #endregion

        #region Constructors

        public PoolService(Transform rootTransform)
        {
            _pools = new Dictionary<string, PoolSpace>(StartCapacity);

            _rootTransform = rootTransform;
        }

        #endregion

        #region Methods

        public bool ContainsPool(string name) =>  _pools.ContainsKey(name);
        
        public void CreatePool(ISpawner spawner)
        {
            if (ContainsPool(spawner.PrefabName)) return;
            
            PoolSpace poolSpace = new PoolSpace(_rootTransform, spawner);

            _pools.Add(spawner.PrefabName, poolSpace);
        }

        public bool TryGetSpawner(string spawnerName, out ISpawner spawner)
        {
            spawner = null;

            if (!ContainsPool(spawnerName))
            {
                return false;
            };

            spawner = _pools[spawnerName].Spawner;

            return true;
        }

        public bool TryInstantiate(string gameObjectName, out ISpawnableObject spawnableObject)
        {
            spawnableObject = null;

            if (!ContainsPool(gameObjectName))
            {
                return false;
            };

            spawnableObject = _pools[gameObjectName].Pop();

            return true;
        }

        public bool TryDestroy(ISpawnableObject spawnableObject)
        {
            var poolName = spawnableObject.Gameobject.name;

            if (!ContainsPool(poolName))
            {
                return false;
            };

            _pools[poolName].Push(spawnableObject);

            return true;
        }
                
        #endregion
    }
}