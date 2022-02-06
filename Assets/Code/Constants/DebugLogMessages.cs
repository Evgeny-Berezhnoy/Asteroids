using UnityEngine;

namespace Constants
{
    public static class DebugLogMessages
    {
        #region Static methods

        public static string EnemyDied(GameObject gameObject) => $"{gameObject.name} has died.";

        #endregion
    }
}
