using UnityEngine;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Configurations/User Interface")]
    public class UserInterfaceConfiguration : ScriptableObject
    {

        #region Fields

        public string PlayScreenDirectory;
        public string GameOverScreenDirectory;

        #endregion

    }

}