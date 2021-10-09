using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IOverlapper
    {

        #region Methods

        List<GameObject> Overlap();

        #endregion

    }

}