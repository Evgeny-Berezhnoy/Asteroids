using System.Collections.Generic;
using UnityEngine;
using Controllers.Move;
using Interfaces;
using Interfaces.Events;
using Models.Constructables.ConfigurationModels;

namespace Controllers
{
    public class BackgroundController : ISpawnableObject, IUpdate
    {
        #region Fields

        private GameObject _gameObject;

        #endregion

        #region Properties

        public IMovable MoveController { get; set; }

        #endregion

        #region Interfaces properties

        public GameObject Gameobject { get => _gameObject; }

        #endregion

        #region Constructors

        public BackgroundController(GameObject gameObject, BackgroundConfigurationModel backgroundConfigurationModel)
        {
            _gameObject     = gameObject;

            MoveController  = new NavigableMoveController(_gameObject.transform, backgroundConfigurationModel.Speed, new NavigatorController(_gameObject.transform));   
        }

        #endregion

        #region Interface methods

        public void OnUpdate(float deltaTime)
        {
            if (!_gameObject.activeSelf) return;

            if (MoveController is IUpdate updateMoveController)
            {
                updateMoveController.OnUpdate(deltaTime);
            }

            if (MoveController is INavigable navigableController)
            {
                if (navigableController.Navigator.Arrived)
                {
                    _gameObject.SetActive(false);
                };
            };
        }

        #endregion
    }
}