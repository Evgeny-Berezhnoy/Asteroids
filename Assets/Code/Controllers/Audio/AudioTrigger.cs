using System.Collections.Generic;
using Interfaces;

using AudioTriggerDelegate = Constants.Delegates.AudioTriggerDelegate;

namespace Controllers.Audio
{
    public class AudioTrigger : IController, IAudioTrigger
    {
        #region Events

        private event AudioTriggerDelegate _onTrigger;

        #endregion

        #region Fields

        private string _audioclip;
        private string _audiotype;

        private List<AudioTriggerDelegate> _handlers = new List<AudioTriggerDelegate>();

        #endregion

        #region Interfaces Properties

        public List<AudioTriggerDelegate> Handlers => _handlers;

        #endregion

        #region Constructors

        public AudioTrigger(string audioclip, string audioType)
        {
            _audioclip = audioclip;
            _audiotype = audioType;
        }

        #endregion

        #region Destructors

        ~AudioTrigger()
        {
            RemoveAllHandlers();
        }

        #endregion

        #region Interfaces Methods

        public void Play()
        {
            _onTrigger?.Invoke(_audioclip, _audiotype);
        }

        public void AddHandler(AudioTriggerDelegate handler)
        {
            _handlers.Add(handler);

            _onTrigger += handler;
        }

        public void RemoveHandler(AudioTriggerDelegate handler)
        {
            _handlers.Remove(handler);

            _onTrigger -= handler;
        }

        public void RemoveAllHandlers()
        {
            for(int i = 0; i < _handlers.Count; i++)
            {
                _onTrigger -= _handlers[i];
            };

            _handlers.Clear();
        }

        #endregion
    }
}