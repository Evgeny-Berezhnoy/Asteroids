using Interfaces;

namespace Controllers.UI
{

    public abstract class BaseUIController : IController
    {

        public abstract void Enable();

        public abstract void Disable();

    }

}