using UnityEngine;

using WheelScrollDelegate = Constants.Delegates.WheelScrollDelegate;

namespace Controllers.Inputting
{
    public class InputWheelScrollController : InputUnitController<WheelScrollDelegate>
    {

        #region Events

        private event WheelScrollDelegate _onTrigger;

        #endregion

        #region Base Methods

        public void Trigger(Vector2 wheelScroll) => _onTrigger?.Invoke(wheelScroll);
        
        public override void AddHandler(WheelScrollDelegate handler)
        {
            _onTrigger += handler;

            base.AddHandler(handler);
        }

        public override void RemoveHandler(WheelScrollDelegate handler)
        {
            _onTrigger -= handler;

            base.RemoveHandler(handler);
        }

        public override void RemoveAllHandlers()
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                _onTrigger -= _handlers[i];
            };

            base.RemoveAllHandlers();
        }

        #endregion
    }
}