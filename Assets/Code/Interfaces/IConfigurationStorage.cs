using System.Collections.Generic;

namespace Interfaces
{
    public interface IConfigurationStorage
    {
        #region Properties

        List<string> Configurations { get; }

        #endregion
    }
}