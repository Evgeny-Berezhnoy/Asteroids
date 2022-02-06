using Interfaces;

namespace Controllers.UI
{
    public abstract class BaseUIController : IController
    {
        #region Methods
         
        public abstract void Enable();

        public abstract void Disable();

        #endregion
    }
}