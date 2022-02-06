using System.Collections.Generic;
using UnityEngine;
using Constants;
using Interfaces;
using Models.Constructables;

namespace Controllers.Shooters
{
    public class ShooterSwapperController : IController
    {

        #region Fields

        private PlayerShooterController _playerShooterController;
        private LinkedList<ShooterModel> _shooterModels = new LinkedList<ShooterModel>();
        private LinkedListNode<ShooterModel> _currentShooter;
        
        #endregion

        #region Constructors

        public ShooterSwapperController(PlayerShooterController playerShooterController, LinkedList<ShooterModel> shooterModels)
        {
            _playerShooterController    = playerShooterController;
            _shooterModels              = shooterModels;
            _currentShooter             = shooterModels.First;
            
            if (_currentShooter == null)
            {
                Debug.LogError(ErrorMessages.SHOOTER_MODELS_NOT_TRANSFERED);

                return;
            };

            playerShooterController.SetShooterModel(_currentShooter.Value);
        }

        #endregion

        #region Methods

        public void ChangeWeapon(Vector2 wheelShift)
        {
            if(_currentShooter == null)
            {
                Debug.LogError(ErrorMessages.SHOOTER_MODELS_NOT_TRANSFERED);

                return;
            }

            if (wheelShift.Equals(Vector2.down))
            {
                _currentShooter = _currentShooter.Previous;

                if(_currentShooter == null)
                {
                    _currentShooter = _shooterModels.Last;
                };
            }
            else
            {
                _currentShooter = _currentShooter.Next;

                if (_currentShooter == null)
                {
                    _currentShooter = _shooterModels.First;
                };
            };

            _playerShooterController.SetShooterModel(_currentShooter.Value);
        }

        #endregion
    }
}
