using UnityEngine;

namespace Interfaces
{
    public interface IAudioClipController : IController
    {
        #region Properties

        AudioClip AudioClip { get; }
        AudioSource AudioSource { get; }
        bool IsPlaying { get; }

        #endregion

        #region Methods

        void Play();
        void Stop();

        #endregion
    }
}