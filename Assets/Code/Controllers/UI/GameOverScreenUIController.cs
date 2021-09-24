using System;
using UnityEngine;
using Constants;
using Interfaces.Events;
using Views.Components.UI;

using Object = UnityEngine.Object;

namespace Controllers.UI
{
    public class GameOverScreenController : BaseUIController, IUpdate
    {

        #region Fields

        private CanvasGroup _screenCanvasGroup;
        
        private float _fadingLength;
        private float _fadingLengthCurrent;
        private bool _isEnabled;

        #endregion

        #region Constructors

        public GameOverScreenController(GameObject prefab, RectTransform userInterfaceTransform)
        {

            var gameObject = Object.Instantiate(prefab, userInterfaceTransform);

            if (!gameObject.TryGetComponent<GameOverScreen>(out var gameOverScreen))
            {

                throw new MissingComponentException(ErrorMessages.MissingComponentException(this.GetType(), typeof(GameOverScreen)));

            };


            _screenCanvasGroup = gameOverScreen.CanvasGroup;

            _fadingLength           = gameOverScreen.FadingLength;

            if(_fadingLength == 0)
            {

                throw new Exception(ErrorMessages.NumbericIsEmpty(this.GetType(), "Fading length"));

            };

            Disable();

        }

        #endregion

        #region Base Methods

        public void OnUpdate(float deltaTime)
        {

            if (!_isEnabled
                    || _screenCanvasGroup.alpha == 1) return;

            _fadingLengthCurrent += deltaTime;
            _fadingLengthCurrent = Mathf.Clamp(_fadingLengthCurrent, 0, _fadingLength);

            _screenCanvasGroup.alpha = _fadingLengthCurrent / _fadingLength;

        }
        
        public override void Disable()
        {

            _screenCanvasGroup.alpha = 0;

            _fadingLengthCurrent = 0;

            _isEnabled = false;

        }

        public override void Enable()
        {

            _isEnabled = true;

        }

        #endregion

    }

}