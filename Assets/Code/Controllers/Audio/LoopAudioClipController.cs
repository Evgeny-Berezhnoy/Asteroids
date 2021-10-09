using UnityEngine;
using ExtensionCompilation;
using Interfaces;
using Interfaces.Events;
using Models.Constructables.ConfigurationModels;
using Models.ScriptableObjects;

namespace Controllers.Audio
{

    public class LoopAudioclipController : IAudioClipController, IUpdate
    {

        #region Fields

        private AudioSource _audioSource;
        private float _loopBeginning;
        private float _loopEnd;
        private bool _loopEntered = false;

        #endregion

        #region Properties

        public AudioClip AudioClip => _audioSource.clip;
        public AudioSource AudioSource => _audioSource;
        public bool IsPlaying => _audioSource.isPlaying;

        #endregion

        #region Constructors

        public LoopAudioclipController(AudioclipConfigurationModel audioclipConfiguration, Transform rootTransform)
        {

            var gameObject              = new GameObject(audioclipConfiguration.GameobjectName);
            
            gameObject.transform.SetParent(rootTransform);
            gameObject.transform.SetLocalPositionAndRotation();

            _audioSource                = gameObject.GetComponentAbsent<AudioSource>();
            _audioSource.clip           = audioclipConfiguration.Audioclip;
            _audioSource.playOnAwake    = false;
            _audioSource.loop           = true;
            _audioSource.spatialBlend   = 0;
            
            _loopBeginning              = audioclipConfiguration.LoopBegining;
            _loopEnd                    = audioclipConfiguration.LoopEnd;
            
        }

        #endregion

        #region Interfaces Methods

        public void Play()
        {

            if (_audioSource.isPlaying)
            {

                return;

            };

            _audioSource.Play();

            _loopEntered = false;

        }

        public void Stop()
        {

            if (_audioSource.isPlaying)
            {

                _audioSource.Stop();

            };

            _loopEntered = false;

        }

        public void OnUpdate(float deltaTime)
        {
            
            if(!_loopEntered && (_audioSource.time > _loopBeginning))
            {

                _loopEntered = true;

            };

            if(_audioSource.time > _loopEnd)
            {

                _audioSource.time = _loopBeginning;
                _audioSource.PlayScheduled(_loopBeginning);

            };

        }

        #endregion

    }

}