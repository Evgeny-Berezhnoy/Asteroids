using System.Collections.Generic;
using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Configurations/Audio/Storage")]
    public class AudioStorage : ScriptableObject
    {
        #region Fields

        public string LevelAudioclipDirectory;
        public List<string> SoundDirectories;

        #endregion
    }
}