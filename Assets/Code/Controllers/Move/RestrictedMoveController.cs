using UnityEngine;
using Interfaces;

namespace Controllers.Move
{
    public class RestrictedMoveController : IMovable
    {

        #region Fields

        private readonly Camera _camera;
        private Transform _travelerTransform;

        #endregion

        #region Properties

        public float Speed { get; set; }

        public Transform TravelerTransform => _travelerTransform;

        #endregion

        #region Constructors

        public RestrictedMoveController(Transform transform, float speed)
        {

            _travelerTransform = transform;

            Speed = speed;

            _camera = Camera.main;

        }

        #endregion

        #region Interfaces Methods

        public void Move(Vector3 direction, float deltaTime)
        {

            float restrictionX          = _camera.orthographicSize * _camera.aspect;
            float restrictionY          = _camera.orthographicSize;

            float moveDirectionX        = _travelerTransform.position.x + direction.x * (deltaTime * Speed);
            float moveDirectionY        = _travelerTransform.position.y + direction.y * (deltaTime * Speed);
            
            Vector3 travelerPosition    = _travelerTransform.position;

            if (Mathf.Abs(moveDirectionX) < restrictionX)
            {

                travelerPosition.x = moveDirectionX;

            };

            if (Mathf.Abs(moveDirectionY) < restrictionY)
            {

                travelerPosition.y = moveDirectionY;

            };

            _travelerTransform.position = travelerPosition;

        }

        #endregion

    }

}
