using System.Collections.Generic;
using Interfaces;
using Interfaces.Events;

namespace Controllers
{

    public class ControllersList : IUpdate, IFixedUpdate
    {

        #region Fields

        private List<IController> _gameControllers;
        private List<IUpdate> _updateControllers;
        private List<IFixedUpdate> _fixedUpdateControllers;

        #endregion

        #region Constructors

        public ControllersList()
        {

            _gameControllers = new List<IController>();
            _updateControllers = new List<IUpdate>();
            _fixedUpdateControllers = new List<IFixedUpdate>();

        }

        #endregion

        #region Methods

        public void AddController(IController gameController)
        {

            _gameControllers.Add(gameController);

            if (gameController is IUpdate updateController)
            {

                _updateControllers.Add(updateController);

            };

            if (gameController is IFixedUpdate fixedUpdateController)
            {

                _fixedUpdateControllers.Add(fixedUpdateController);

            };
            
        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {
            
            for(var i = 0; i < _updateControllers.Count; i++)
            {

                _updateControllers[i].OnUpdate(deltaTime);

            };

        }

        public void OnFixedUpdate()
        {

            for (var i = 0; i < _fixedUpdateControllers.Count; i++)
            {

                _fixedUpdateControllers[i].OnFixedUpdate();

            };

        }

        #endregion

    }

}