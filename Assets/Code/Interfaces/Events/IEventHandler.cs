using System.Collections.Generic;

namespace Interfaces.Events
{
    public interface IEventHandler<T>
    {
        #region Properties

        List<T> Handlers { get; }

        #endregion

        #region Methods

        void AddHandler(T handler);
        void RemoveHandler(T handler);
        void RemoveAllHandlers();

        #endregion
    }
}
