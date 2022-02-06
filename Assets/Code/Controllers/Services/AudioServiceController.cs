using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Constants;
using Controllers.Audio;
using Interfaces;
using Interfaces.Events;
using Models.Constructables.ConfigurationModels;

namespace Controllers.Services
{
    public class AudioServiceController : IController, IUpdate, IGameStatementListener
    {
        #region Fields

        private IAudioClipController _levelAudioclipController;
        private Dictionary<string, IAudioClipController> _sounds = new Dictionary<string, IAudioClipController>();
        private GameStateController _gameStateController;

        #endregion

        #region Constructors

        public AudioServiceController(AudioConfigurationModel audioConfigurationModel, Transform rootTransform, GameStateController gameStateController)
        {
            _gameStateController        = gameStateController;
            _levelAudioclipController   = CreateAudioclipController(audioConfigurationModel.Level, rootTransform);
            
            for(int i = 0; i < audioConfigurationModel.Sounds.Count; i++)
            {
                _sounds.Add(audioConfigurationModel.Sounds[i].ConfigurationDirectory, CreateAudioclipController(audioConfigurationModel.Sounds[i], rootTransform));
            };
        }

        #endregion

        #region Methods

        public void Play(string audiotrackName, string audioType)
        {
            if (audioType.Equals(AudioTypes.LEVEL))
            {
                PlayLevel();
            }
            else if (audioType.Equals(AudioTypes.SOUND))
            {
                PlaySound(audiotrackName);
            }
            else
            {
                throw new Exception(ErrorMessages.InvalidAudioType(audioType));
            };
        }

        private IAudioClipController CreateAudioclipController(AudioclipConfigurationModel audioclipConfigurationModel, Transform rootTransform)
        {
            if (audioclipConfigurationModel.Loop)
            {
                return new LoopAudioclipController(audioclipConfigurationModel, rootTransform);
            }
            else
            {
                return new AudioclipController(audioclipConfigurationModel, rootTransform);
            };
        }

        private void PlayLevel()
        {
            if (_levelAudioclipController == null
                    || _levelAudioclipController.AudioClip == null)
            {
                Debug.LogError(ErrorMessages.MissingAudio(AudioTypes.LEVEL));

                return;
            };

            _levelAudioclipController.Play();
        }

        private void PlaySound(string configurationDirectory)
        {
            if (!_sounds.ContainsKey(configurationDirectory))
            {
                Debug.LogError(ErrorMessages.MissingAudio(configurationDirectory, AudioTypes.SOUND));

                return;
            };

            _sounds[configurationDirectory].Play();
        }

        private void StopDictionaryAudiotracks(Dictionary<string, IAudioClipController> audiotracksDictionary)
        {
            var audiotracksValues = audiotracksDictionary.Values.ToArray();

            for (int i = 0; i < audiotracksValues.Length; i++)
            {
                audiotracksValues[i].Stop();
            };
        }

        private void UpdateDictionaryAudiotracks(Dictionary<string, IAudioClipController> audiotracksDictionary, float deltaTime)
        {
            var audiotracksValues =
                audiotracksDictionary
                    .Values
                    .ToArray()
                    .Where(x => x is IUpdate)
                    .Cast<IUpdate>()
                    .ToArray();

            for (int i = 0; i < audiotracksValues.Length; i++)
            {
                audiotracksValues[i].OnUpdate(deltaTime);
            };
        }

        #endregion

        #region Interfaces Methods

        public void StartGame() => _levelAudioclipController.Play();
        public void StopGame() => _levelAudioclipController.Stop();
        public void OnUpdate(float deltaTime)
        {
            if (_gameStateController.GameIsStopped) return;

            if(_levelAudioclipController is IUpdate levelAudioUpdate)
            {
                levelAudioUpdate.OnUpdate(deltaTime);
            }

            UpdateDictionaryAudiotracks(_sounds, deltaTime);
        }

        #endregion
    }
}