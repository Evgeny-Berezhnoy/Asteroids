namespace Interfaces
{
    public interface ILifeTime
    {
        #region Properties

        float LifeTime { get; set; }
        float CurrentLifeTime { get; set; }
        bool IsAlive { get; }

        #endregion
    }
}