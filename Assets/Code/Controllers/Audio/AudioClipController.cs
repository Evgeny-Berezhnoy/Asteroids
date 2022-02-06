using UnityEngine;
using ExtensionCompilation;
using Interfaces;
using Models.Constructables.ConfigurationModels;

namespace Controllers.Audio
{
    public class AudioclipController : IAudioClipController
    {
        #region Fields

        private AudioSource _audioSource;

        #endregion

        #region Interfaces properties

        public AudioClip AudioClip      => _audioSource.clip;
        public AudioSource AudioSource  => _audioSource;
        public bool IsPlaying           => _audioSource.isPlaying;

        #endregion

        #region Constructors

        public AudioclipController(AudioclipConfigurationModel audioclipConfiguration, Transform rootTransform)
        {
            var gameObject              = new GameObject(audioclipConfiguration.GameobjectName);
            
            gameObject.transform.SetParent(rootTransform);
            gameObject.transform.SetLocalPositionAndRotation();
            
            _audioSource                = gameObject.GetComponentAbsent<AudioSource>();
            _audioSource.clip           = audioclipConfiguration.Audioclip;
            _audioSource.playOnAwake    = false;
            _audioSource.loop           = false;
            _audioSource.spatialBlend   = 0;
        }

        #endregion

        #region Interfaces properties

        public void Play() => _audioSource.Play();

        public void Stop()
        {
            if (!_audioSource.isPlaying) return;
                
            _audioSource.Stop();
        }

        #endregion
    }
}