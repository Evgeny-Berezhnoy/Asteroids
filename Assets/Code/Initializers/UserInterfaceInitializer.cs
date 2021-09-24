using UnityEngine;
using Controllers;
using Controllers.UI;
using Interfaces;
using Models.ScriptableObjects;

namespace Initializers
{
    public class UserInterfaceInitializer : IGameInitializer
    {

        #region Constructors

        public UserInterfaceInitializer(GameConfiguration gameConfiguration, ControllersList controllersList, RectTransform userInterfaceTransform, GameEventsHandler gameEventsHandler, PointsController pointsController)
        {

            var userInterfaceController = new UserInterfaceController(gameConfiguration.UserInterfaceConfiguration, userInterfaceTransform, gameEventsHandler, pointsController);

            controllersList.AddController(userInterfaceController);

        }

        #endregion

    }

}
