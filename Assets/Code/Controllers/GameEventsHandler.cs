using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Controllers
{
    public class GameEventsHandler : IController, IGameStatementListener
    {
        
        #region Events

        private event Action _onRestart;
        private event Action _onGameOver;
        
        #endregion

        #region Fields

        private List<Action> _onGameOverHandlers;
        private List<Action> _onRestartHandlers;

        #endregion

        #region Constructors

        public GameEventsHandler()
        {

            _onGameOverHandlers     = new List<Action>();
            _onRestartHandlers      = new List<Action>();

        }

        #endregion

        #region Destructors

        ~GameEventsHandler()
        {

            RemoveAllGameOverHandlers();

            RemoveAllRestartHandlers();

        }

        #endregion

        #region Methods

        public void AddGameOverHandler(Action handler)
        {

            _onGameOverHandlers.Add(handler);

            _onGameOver += handler;

        }

        public void RemoveGameOverHandler(Action handler)
        {

            if (!_onGameOverHandlers.Any(x => x.Equals(handler)))
            {

                return;

            }

            _onGameOver -= handler;

            _onGameOverHandlers.Remove(handler);

        }

        public void RemoveAllGameOverHandlers()
        {

            for (var i = 0; i < _onGameOverHandlers.Count; i++)
            {

                _onGameOver -= _onGameOverHandlers[i];

            };

            _onGameOverHandlers.Clear();

        }

        public void AddRestartHandler(Action handler)
        {

            _onRestartHandlers.Add(handler);

            _onRestart += handler;

        }

        public void RemoveRestartHandler(Action handler)
        {

            if (!_onRestartHandlers.Any(x => x.Equals(handler)))
            {

                return;

            }

            _onRestart -= handler;

            _onRestartHandlers.Remove(handler);

        }

        public void RemoveAllRestartHandlers()
        {

            for (var i = 0; i < _onRestartHandlers.Count; i++)
            {

                _onRestart -= _onRestartHandlers[i];

            };

            _onRestartHandlers.Clear();

        }

        public void StartGame()
        {

            _onRestart?.Invoke();

        }

        public void StopGame()
        {

            _onGameOver?.Invoke();

        }

        #endregion

    }

}