using System;

namespace Controllers.Inputting
{
    public class InputActionController : InputUnitController<Action>
    {
        #region Events

        private event Action _onTrigger;

        #endregion

        #region Base Methods

        public void Trigger() => _onTrigger?.Invoke();

        public override void AddHandler(Action handler)
        {
            _onTrigger += handler;

            base.AddHandler(handler);
        }

        public override void RemoveHandler(Action handler)
        {
            _onTrigger -= handler;

            base.RemoveHandler(handler);
        }

        public override void RemoveAllHandlers()
        {
            for(int i = 0; i < _handlers.Count; i++)
            {
                _onTrigger -= _handlers[i];
            };

            base.RemoveAllHandlers();
        }

        #endregion
    }
}