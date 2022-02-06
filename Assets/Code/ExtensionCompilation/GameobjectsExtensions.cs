using UnityEngine;

namespace ExtensionCompilation
{
    public static class GameobjectsExtensions
    {

        #region Static methods

        public static GameObject AddComponentAbsent<T>(this GameObject gameObject)
            where T : Component
        {
            if(gameObject.GetComponent<T>() == null)
            {
                gameObject.AddComponent<T>();
            };

            return gameObject;
        }

        public static T GetComponentAbsent<T>(this GameObject gameObject)
            where T : Component
        {
            return gameObject.AddComponentAbsent<T>().GetComponent<T>();
        }

        public static GameObject AddSpriteRendererAbsent(this GameObject gameObject, Sprite sprite, int orderInLayer = 1)
        {
            var spriteRenderer = gameObject.GetComponentAbsent<SpriteRenderer>();

            spriteRenderer.sprite       = sprite;
            spriteRenderer.sortingOrder = orderInLayer;
            
            return gameObject;
        }

        public static GameObject AddCircleCollider2DAbsent(this GameObject gameObject) => gameObject.AddComponentAbsent<CircleCollider2D>();

        #endregion
    }
}