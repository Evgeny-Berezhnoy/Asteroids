using UnityEngine;

using WheelScrollDelegete = Constants.Delegates.WheelScrollDelegete;

namespace Controllers.Inputting
{
    public class InputWheelScrollController : InputUnitController<WheelScrollDelegete>
    {

        #region Events

        private event WheelScrollDelegete _onTrigger;

        #endregion

        #region Base Methods

        public void Trigger(Vector2 wheelScroll)
        {

            _onTrigger?.Invoke(wheelScroll);

        }

        public override void AddHandler(WheelScrollDelegete handler)
        {

            _onTrigger += handler;

            base.AddHandler(handler);

        }

        public override void RemoveHandler(WheelScrollDelegete handler)
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