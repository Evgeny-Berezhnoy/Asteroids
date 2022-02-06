using Interfaces;

namespace Models.Constructables.Templates
{
    public abstract class ConfigurationModel : IConfigurationModel
    {
        #region Properties

        public string ConfigurationDirectory { get; protected set; }

        #endregion

        #region Constructors

        public ConfigurationModel(string configurationDirectory)
        {
            ConfigurationDirectory = configurationDirectory;
        }

        #endregion
    }
}