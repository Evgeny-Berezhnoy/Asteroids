namespace Interfaces.Events
{
    public interface IUpdate
    {
        #region Methods

        void OnUpdate(float deltaTime);

        #endregion
    }
}