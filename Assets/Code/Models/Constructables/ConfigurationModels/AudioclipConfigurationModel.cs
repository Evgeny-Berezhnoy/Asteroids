using UnityEngine;
using Interfaces;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{
    public class AudioclipConfigurationModel : ConfigurationModel, IPrefabData
    {

        #region Fields

        [SerializeField] private string _name;

        public bool Loop;
        public float LoopBegining;
        public float LoopEnd;

        public AudioClip Audioclip;

        #endregion

        #region Interfaces Properties

        public string GameobjectName => _name;

        #endregion

        #region Constructors

        public AudioclipConfigurationModel(string configurationDirectory) : base(configurationDirectory)
        {
            
            var audioclipConfiguration = ModelsInitializer.LoadObject<AudioclipConfiguration>(configurationDirectory);

            _name           = audioclipConfiguration.Name;

            Loop            = audioclipConfiguration.Loop;
            LoopBegining    = audioclipConfiguration.LoopBegining;
            LoopEnd         = audioclipConfiguration.LoopEnd;

            ModelsInitializer.InitializeObject(ref Audioclip, audioclipConfiguration.AudioclipDirectory);

        }

        #endregion

    }

}
