using UnityEngine;

namespace Views.Components.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverScreen : MonoBehaviour
    {
        #region Fields

        [SerializeField] public CanvasGroup CanvasGroup;
        [SerializeField] public float FadingLength;

        #endregion
    }
}