using UnityEngine;

namespace Interfaces
{
    public interface ISpawnableObject : IController
    {
        #region Properties

        GameObject Gameobject { get; }

        #endregion
    }
}