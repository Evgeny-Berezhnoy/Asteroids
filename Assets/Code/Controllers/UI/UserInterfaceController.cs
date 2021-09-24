using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Interfaces;
using Interfaces.Events;
using Models.ScriptableObjects;

namespace Controllers.UI
{
    public class UserInterfaceController : IController, IUpdate 
    {

        #region Fields
        
        private PlayScreenController _playScreenController;
        private GameOverScreenController _gameOverScreenController;

        private Stack<BaseUIController> _openedWindows;
        private List<IUpdate> _updateControllers;
        
        #endregion

        #region Constructors

        public UserInterfaceController(UserInterfaceConfiguration userInterfaceConfiguration, RectTransform userInterfaceTransform, GameEventsHandler gameEventsHandler, PointsController pointsController)
        {

            _playScreenController       = new PlayScreenController(userInterfaceConfiguration.Points, userInterfaceTransform, pointsController);
            _gameOverScreenController   = new GameOverScreenController(userInterfaceConfiguration.GameOverScreen, userInterfaceTransform);

            _openedWindows              = new Stack<BaseUIController>();
            _updateControllers          = new List<IUpdate>();
            
            gameEventsHandler.AddRestartHandler(ActivatePlayScreen);
            gameEventsHandler.AddGameOverHandler(ActivateGameOverScreen);

            ActivatePlayScreen();

        }

        #endregion

        #region Methods

        public void ActivatePlayScreen()
        {

            _updateControllers.Remove(_gameOverScreenController);

            StartScreen(_playScreenController);

        }

        public void ActivateGameOverScreen()
        {

            if(!_updateControllers.Any(x => x == _gameOverScreenController))
            {

                _updateControllers.Add(_gameOverScreenController);

            };

            StartScreen(_gameOverScreenController);

        }

        private void StartScreen(BaseUIController screen)
        {

            for (int i = 0; i < _openedWindows.Count; i++)
            {

                _openedWindows
                    .Pop()
                    .Disable();

            };

            _openedWindows.Push(screen);

            screen.Enable();

        }

        #endregion

        #region Interfaces

        public void OnUpdate(float deltaTime)
        {

            for(int i = 0; i < _updateControllers.Count; i++)
            {

                _updateControllers[i].OnUpdate(deltaTime);

            };

        }

        #endregion

    }

}