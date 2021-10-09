using UnityEngine;
using Interfaces;
using Interfaces.Events;

namespace Controllers.Move
{

    public class NavigableMoveController : IMovable, INavigable, IUpdate
    {

        #region Properties

        public INavigator Navigator { get; set; }
        
        #endregion

        #region Interfaces Properties

        public Transform TravelerTransform { get; private set; }
        public float Speed { get; set; }

        #endregion

        #region Constructors

        public NavigableMoveController(Transform travelerTransform, float speed)
        {

            TravelerTransform   = travelerTransform;
            Speed               = speed;
            
        }
        
        public NavigableMoveController(Transform travelerTransform, float speed, INavigator navigator) : this(travelerTransform, speed)
        {

            Navigator = navigator;

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            if (Navigator == null || Navigator.Arrived) return;

            Move(Navigator.CurrentDestination.Value.position - TravelerTransform.position, deltaTime);

        }

        public void Move(Vector3 direction, float deltaTime)
        {

            Vector3 frameDirection = direction.normalized * Speed * deltaTime;

            if (direction.magnitude < frameDirection.magnitude)
            {

                Navigator.Direct(direction);

            }
            else
            {

                Navigator.Direct(frameDirection);

            };

        }

        #endregion

    }

}