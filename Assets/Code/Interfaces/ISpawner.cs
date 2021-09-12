namespace Interfaces
{

    public interface ISpawner
    {

        #region Properties

        string PrefabName { get; }
        IPrefabData Prefab { get; }

        #endregion

        #region Methods

        ISpawnableObject Spawn();

        #endregion

    }

}