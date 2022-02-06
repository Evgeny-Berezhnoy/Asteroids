using Controllers.Inputting;

namespace Models.Managers
{
    public class InputUnitManager 
    {
        #region Properties

        public InputAxisController GameAxis { get; private set; }
        public InputActionController GameShoot { get; private set; }
        public InputWheelScrollController GameWheel { get; private set; }
        
        public InputAxisController IdleAxis { get; private set; }
        public InputActionController IdleShoot { get; private set; }
        public InputWheelScrollController IdleWheel { get; private set; }

        public InputActionController Restart { get; private set; }

        #endregion

        #region Constructors

        public InputUnitManager()
        {
            GameAxis    = new InputAxisController();
            GameShoot   = new InputActionController();
            GameWheel   = new InputWheelScrollController();
            
            IdleAxis    = new InputAxisController();
            IdleShoot   = new InputActionController();
            IdleWheel   = new InputWheelScrollController();
            
            Restart     = new InputActionController();
        }

        #endregion
    }
}