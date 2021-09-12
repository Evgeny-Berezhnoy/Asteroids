using System.Collections.Generic;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Interfaces;

namespace Controllers
{
    public class NavigatorController : IController, INavigator
    {

        #region Properties

        public Transform TravelerTransform {get; private set;}
        public LinkedList<Transform> Destinations { get; private set; }
        public LinkedListNode<Transform> CurrentDestination { get ; private set; }
        public bool Arrived { get; private set; }

        #endregion

        #region Constructors

        public NavigatorController(Transform travelerTransform)
        {

            TravelerTransform = travelerTransform;

            Arrived = true;

        }

        public NavigatorController(Transform travelerTransform, LinkedList<Transform> destinations) : this(travelerTransform)
        {

            SetRoute(destinations);

        }

        #endregion

        #region Methods

        public void SetRoute(LinkedList<Transform> destinations)
        {

            Arrived = false;

            Destinations = destinations;

            CurrentDestination = destinations.First;

            TravelerTransform.SetPositionAndRotation(CurrentDestination.Value);
            
        }

        #endregion

        #region Interfaces Methods

        public void Direct(Vector3 direction)
        {

            if (Arrived) return;

            TravelerTransform.position += direction;

            if ((CurrentDestination.Value.position - TravelerTransform.position).magnitude > FudgeFactors.DISTANCE_BETWEEN_POSITIONS) return;

            CurrentDestination = CurrentDestination.Next;

            if(CurrentDestination == null)
            {

                Arrived = true;

            };

        }

        #endregion

    }

}