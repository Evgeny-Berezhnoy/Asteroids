using Controllers;
using Controllers.Services;
using Interfaces;
using Models.Constructables.ConfigurationModels;
using Spawnables.Services;

namespace Initializers
{
    public class BackgroundInitializer : IGameInitializer
    {
        #region Constructors

        public BackgroundInitializer(BackgroundConfigurationModel backgroundConfigurationModel, ControllersList controllersList, PoolService poolService)
        {
            var backgroundServiceController = new BackgroundServiceController(backgroundConfigurationModel, poolService);

            controllersList.AddController(backgroundServiceController);
        }

        #endregion
    }
}