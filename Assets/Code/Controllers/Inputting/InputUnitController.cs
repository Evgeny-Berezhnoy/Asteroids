using System;
using System.Collections.Generic;
using Interfaces;
using Interfaces.Events;

namespace Controllers.Inputting
{

    public abstract class InputUnitController<T> : IController, IEventHandler<T>
        where T : Delegate
    {

        #region Fields

        protected List<T> _handlers;

        #endregion

        #region Interfaces Properties

        public List<T> Handlers { get => _handlers; } 

        #endregion

        #region Constructors

        public InputUnitController()
        {

            _handlers = new List<T>();
        
        }

        #endregion

        #region Destructors

        ~InputUnitController()
        {

            RemoveAllHandlers();

        }

        #endregion

        #region Interfaces Methods

        public virtual void AddHandler(T handler)
        {

            _handlers.Add(handler);

        }

        public virtual void RemoveHandler(T handler)
        {

            _handlers.Remove(handler);

        }
        
        public virtual void RemoveAllHandlers()
        {

            _handlers.Clear();

        }

        #endregion

    }

}