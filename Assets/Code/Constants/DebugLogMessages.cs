using UnityEngine;

namespace Constants
{

    public static class DebugLogMessages
    {

        #region Methods

        public static string EnemyDied(GameObject gameObject)
        {

            return $"{gameObject.name} has died.";

        }

        #endregion

    }

}
