using UnityEngine;

using AxisShiftDelegate = Constants.Delegates.AxisShiftDelegate;

namespace Controllers.Inputting
{
    public class InputAxisController : InputUnitController<AxisShiftDelegate>
    {
        #region Events

        private event AxisShiftDelegate _onTrigger;

        #endregion

        #region Base Methods

        public void Trigger(Vector3 axisShift, float deltaTime) => _onTrigger?.Invoke(axisShift, deltaTime);

        public override void AddHandler(AxisShiftDelegate handler)
        {
            _onTrigger += handler;

            base.AddHandler(handler);
        }

        public override void RemoveHandler(AxisShiftDelegate handler)
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