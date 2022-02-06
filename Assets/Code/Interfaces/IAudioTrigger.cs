using Interfaces.Events;

using AudioTriggerDelegate = Constants.Delegates.AudioTriggerDelegate;

namespace Interfaces
{
    public interface IAudioTrigger : IEventHandler<AudioTriggerDelegate>
    {
        #region Methods

        void Play();

        #endregion
    }
}