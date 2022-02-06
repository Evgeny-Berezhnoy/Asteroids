using UnityEngine;

namespace ExtensionCompilation
{
    public static class TransformExtensions
    {
        #region Static methods

        public static Transform SetLocalPositionAndRotation(this Transform transform)
        {
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            return transform;
        }

        public static Transform SetLocalPositionAndRotation(this Transform transform, Transform toTransform)
        {
            transform.SetLocalPositionAndRotation(toTransform.position, toTransform.rotation);

            return transform;
        }

        public static Transform SetLocalPositionAndRotation(this Transform transform, Vector3 localPosition, Quaternion localRotation)
        {
            transform.localPosition = localPosition;
            transform.localRotation = localRotation;

            return transform;
        }

        public static Transform SetPositionAndRotation(this Transform transform)
        {
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            return transform;
        }

        public static Transform SetPositionAndRotation(this Transform transform, Transform toTransform)
        {
            transform.SetPositionAndRotation(toTransform.position, toTransform.rotation);

            return transform;
        }

        public static Transform SetPositionAndRotation(this Transform transform, Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;

            return transform;
        }

        #endregion
    }
}