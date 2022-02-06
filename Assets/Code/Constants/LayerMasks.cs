using UnityEngine;

namespace Constants
{
    public static class LayerMasks
    {
        #region Static fields

        public static readonly LayerMask PLAYER_PROJECTILE  = LayerMask.GetMask(LayerMask.LayerToName(Layers.ENEMY));
        public static readonly LayerMask ENEMY_PROJECTILE   = LayerMask.GetMask(LayerMask.LayerToName(Layers.PLAYER));

        #endregion
    }
}
