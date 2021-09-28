using System.Collections.Generic;
using Models.Constructables.Templates;
using Models.ScriptableObjects;

namespace Models.Constructables.ConfigurationModels
{
    public class AudioConfigurationModel : ConfigurationModel
    {

        #region Fields

        public AudioclipConfigurationModel Level;
        public List<AudioclipConfigurationModel> Sounds = new List<AudioclipConfigurationModel>();
        
        #endregion

        #region Constructors

        public AudioConfigurationModel(string configurationDirectory) : base(configurationDirectory)
        {

            var audioStorage = ModelsInitializer.LoadObject<AudioStorage>(configurationDirectory);

            Level = new AudioclipConfigurationModel(audioStorage.LevelAudioclipDirectory);

            for(int i = 0; i < audioStorage.SoundDirectories.Count; i++)
            {

                Sounds.Add(new AudioclipConfigurationModel(audioStorage.SoundDirectories[i]));

            };

        }

        #endregion

    }

}