using System;
using UnityEngine;
using Constants.InputNames;
using Interfaces;
using Interfaces.Events;
using Models.Managers;

namespace Controllers.Inputting
{
    public class InputController : IController, IUpdate, IGameStatementListener
    {

        #region Fields

        private InputUnitManager _inputUnitManager;
        
        private InputAxisController _inputAxis;
        private InputActionController _inputShoot;
        private InputActionController _inputRestart;
        private InputWheelScrollController _inputWheel;
        
        private Vector3 _axisShift => new Vector3(Input.GetAxis(InputAxis.HORIZONTAL), Input.GetAxis(InputAxis.VERTICAL));

        #endregion

        #region Constructors

        public InputController(InputUnitManager inputUnitManager)
        {

            _inputUnitManager       = inputUnitManager;
            
            _inputAxis              = _inputUnitManager.GameAxis;
            _inputShoot             = _inputUnitManager.GameShoot;
            _inputRestart           = _inputUnitManager.Restart;
            _inputWheel             = _inputUnitManager.GameWheel;

        }

        #endregion

        #region Methods

        private void CheckAxisShift(float deltaTime)
        {

            if (_axisShift.magnitude > 0)
            {

                _inputAxis?.Trigger(_axisShift, deltaTime);

            };

        }

        private void CheckShootPress()
        {

            if (Input.GetButton(InputButtons.FIRE))
            {

                _inputShoot?.Trigger();

            };

        }

        private void CheckRestartPress()
        {

            if (Input.GetButton(InputButtons.RESTART))
            {

                _inputRestart?.Trigger();

            };

        }

        private void CheckMouseScroll()
        {

            if (Input.mouseScrollDelta != InputWheel.IDLE)
            {

                _inputWheel?.Trigger(Input.mouseScrollDelta);

            };

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            CheckAxisShift(deltaTime);

            CheckShootPress();

            CheckRestartPress();

            CheckMouseScroll();

        }

        public void StartGame()
        {

            _inputAxis  = _inputUnitManager.GameAxis;
            _inputShoot = _inputUnitManager.GameShoot;
            _inputWheel = _inputUnitManager.GameWheel;

        }

        public void StopGame()
        {

            _inputAxis  = _inputUnitManager.IdleAxis;
            _inputShoot = _inputUnitManager.IdleShoot;
            _inputWheel = _inputUnitManager.IdleWheel;
            
        }

        #endregion

    }

}