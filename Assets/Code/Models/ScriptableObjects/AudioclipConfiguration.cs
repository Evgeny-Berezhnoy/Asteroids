using UnityEngine;

namespace Models.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Configurations/Audio/Clip")]
    public class AudioclipConfiguration : ScriptableObject
    {

        #region Fields

        public string Name;
        public string AudioclipDirectory;
        public bool Loop;
        public float LoopBegining;
        public float LoopEnd;
        
        #endregion

    }

}
