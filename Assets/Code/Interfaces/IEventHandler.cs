namespace Interfaces.Events
{
    public interface IEventHandler<T>
    {

        #region Methods

        void AddHandler(T handler);

        void RemoveHandler(T handler);

        void RemoveAllHandlers();

        #endregion

    }

}
