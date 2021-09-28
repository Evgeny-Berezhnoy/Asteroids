using UnityEngine;
using Controllers;
using Controllers.UI;
using Interfaces;
using Models.Constructables.ConfigurationModels;

namespace Initializers
{
    public class UserInterfaceInitializer : IGameInitializer
    {

        #region Constructors

        public UserInterfaceInitializer(GameConfigurationModel gameConfiguration, ControllersList controllersList, RectTransform userInterfaceTransform, GameEventsHandler gameEventsHandler, PointsController pointsController)
        {

            var userInterfaceController = new UserInterfaceController(gameConfiguration.UserInterface, userInterfaceTransform, gameEventsHandler, pointsController);

            controllersList.AddController(userInterfaceController);

        }

        #endregion

    }

}
