using UnityEngine;
using ExtensionCompilation;
using Interfaces;
using Berezhnoy.Collections.Generic;

namespace Spawnables.Pools
{
    public class PoolSpace
    {

        #region Fields

        private Transform _rootPool;
        private ISpawner _spawner;
        private OpenQueue<ISpawnableObject> _spawnableObjectsQueue;

        #endregion

        #region Properties

        public ISpawner Spawner => _spawner;

        #endregion

        #region Constructors

        public PoolSpace(Transform rootPool, ISpawner spawner, int startQuntity = 0)
        {

            _rootPool               = rootPool;
            _spawnableObjectsQueue  = new OpenQueue<ISpawnableObject>();
            _spawner                = spawner;

            for (var i = 0; i < startQuntity; i++)
            {

                ISpawnableObject spawnableObject = CreateObject();

                _spawnableObjectsQueue.Enqueue(spawnableObject);

            };

        }

        #endregion

        #region Methods

        public ISpawnableObject Pop()
        {

            ISpawnableObject spawnableObject = _spawnableObjectsQueue.Dequeue();

            if(spawnableObject == null)
            {

                spawnableObject = CreateObject();

            };

            EnableObject(spawnableObject);

            return spawnableObject;

        }

        public void Push(ISpawnableObject spawnableObject)
        {

            DisableObject(spawnableObject);

            _spawnableObjectsQueue.Enqueue(spawnableObject);

        }

        private ISpawnableObject CreateObject()
        {

            var spawnableObject = _spawner.Spawn();

            DisableObject(spawnableObject);

            return spawnableObject;

        }

        private void EnableObject(ISpawnableObject spawnableObject)
        {

            spawnableObject.Gameobject.transform.SetParent(null);
            spawnableObject.Gameobject.SetActive(true);

        }

        private void DisableObject(ISpawnableObject spawnableObject)
        {

            spawnableObject.Gameobject.transform.parent = _rootPool;
            spawnableObject.Gameobject.transform.SetLocalPositionAndRotation();
            spawnableObject.Gameobject.SetActive(false);

        }

        #endregion

    }

}