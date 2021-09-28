using Interfaces;

namespace Spawnables.Spawners.Templates
{
    public abstract class Spawner<T> : ISpawner
        where T : class, IPrefabData
    {

        #region Fields

        protected string _prefabName;
        protected T _prefab;

        #endregion

        #region Properties

        public string PrefabName { get => _prefabName; }
        public IPrefabData Prefab => _prefab;

        #endregion

        #region Constructors

        public Spawner(IPrefabData prefab, string prefabName)
        {

            _prefabName             = prefabName;
            _prefab                 = prefab as T;
            
        }

        #endregion

        #region Interfaces Methods

        public abstract ISpawnableObject Spawn();

        #endregion

    }
}
