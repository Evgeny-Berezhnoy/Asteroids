using UnityEngine;

namespace Interfaces
{
    public interface IMovable
    {

        #region Properties

        Transform TravelerTransform { get; }
        float Speed { get; set; }

        #endregion

        #region Methods

        void Move(Vector3 direction, float deltaTime);

        #endregion

    }

}