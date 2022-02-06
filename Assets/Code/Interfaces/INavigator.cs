using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface INavigator
    {
        #region Properties

        Transform TravelerTransform { get; }
        LinkedListNode<Transform> CurrentDestination { get; }
        LinkedList<Transform> Destinations { get; }
        bool Arrived { get; }

        #endregion

        #region Methods

        void SetRoute(LinkedList<Transform> destinations, LinkedListNode<Transform> currentDestination = null);
        void Direct(Vector3 direction);

        #endregion
    }
}