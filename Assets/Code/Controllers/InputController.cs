using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Constants.InputNames;
using Interfaces;
using Interfaces.Events;

namespace Controllers
{
    public class InputController : IController, IUpdate
    {

        #region Delegates

        public delegate void AxisShiftDelegate(Vector3 axisShift, float deltaTime);
        public delegate void WheelScrollDelegete(Vector2 wheelScroll);

        #endregion

        #region Events

        public event AxisShiftDelegate OnAxisShift;
        public event Action OnShootPress;
        public event WheelScrollDelegete OnWheelScroll;

        #endregion

        #region Fields

        private List<AxisShiftDelegate> _onAxisShiftHandlers;
        private List<Action> _onShootPressHandlers;
        private List<WheelScrollDelegete> _onWheelScrollHandlers;
        
        private Vector3 _axisShift => new Vector3(Input.GetAxis(InputAxis.HORIZONTAL), Input.GetAxis(InputAxis.VERTICAL));

        #endregion

        #region Constructors

        public InputController()
        {

            _onAxisShiftHandlers    = new List<AxisShiftDelegate>();
            _onShootPressHandlers   = new List<Action>();
            _onWheelScrollHandlers  = new List<WheelScrollDelegete>();

        }

        #endregion

        #region Destructors

        ~InputController()
        {

            RemoveAllAxisHandlers();

            RemoveAllShootHandlers();

        }

        #endregion

        #region Methods

        public void AddAxisHandler(AxisShiftDelegate handler)
        {

            _onAxisShiftHandlers.Add(handler);

            OnAxisShift += handler;

        }

        public void RemoveAxisHandler(AxisShiftDelegate handler)
        {

            if (!_onAxisShiftHandlers.Any(x => x.Equals(handler)))
            {

                return;

            }

            OnAxisShift -= handler;

            _onAxisShiftHandlers.Remove(handler);

        }

        public void RemoveAllAxisHandlers()
        {

            for (var i = 0; i < _onAxisShiftHandlers.Count; i++)
            {

                OnAxisShift -= _onAxisShiftHandlers[i];

            };

            _onAxisShiftHandlers.Clear();

        }

        public void AddShootHandler(Action handler)
        {

            _onShootPressHandlers.Add(handler);

            OnShootPress += handler;

        }

        public void RemoveShootHandler(Action handler)
        {

            if (!_onShootPressHandlers.Any(x => x.Equals(handler)))
            {

                return;

            }

            OnShootPress -= handler;

            _onShootPressHandlers.Remove(handler);

        }

        public void RemoveAllShootHandlers()
        {

            for (var i = 0; i < _onShootPressHandlers.Count; i++)
            {

                OnShootPress -= _onShootPressHandlers[i];

            };

            _onShootPressHandlers.Clear();

        }

        public void AddWheelScrollHandler(WheelScrollDelegete handler)
        {

            _onWheelScrollHandlers.Add(handler);

            OnWheelScroll += handler;

        }

        public void RemoveWheelScrollHandler(WheelScrollDelegete handler)
        {

            if (!_onWheelScrollHandlers.Any(x => x.Equals(handler)))
            {

                return;

            }

            OnWheelScroll -= handler;

            _onWheelScrollHandlers.Remove(handler);

        }

        public void RemoveAllWheelScrollHandlers()
        {

            for (var i = 0; i < _onWheelScrollHandlers.Count; i++)
            {

                OnWheelScroll -= _onWheelScrollHandlers[i];

            };

            _onWheelScrollHandlers.Clear();

        }

        private void CheckAxisShift(float deltaTime)
        {

            if (_axisShift.magnitude > 0)
            {

                OnAxisShift?.Invoke(_axisShift, deltaTime);

            };

        }

        private void CheckShootPress()
        {

            if (Input.GetButton(InputButtons.FIRE))
            {

                OnShootPress?.Invoke();

            };

        }

        private void CheckMouseScroll()
        {

            if (Input.mouseScrollDelta != InputWheel.IDLE)
            {

                OnWheelScroll?.Invoke(Input.mouseScrollDelta);

            };

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            CheckAxisShift(deltaTime);

            CheckShootPress();

            CheckMouseScroll();

        }

        #endregion

    }

}