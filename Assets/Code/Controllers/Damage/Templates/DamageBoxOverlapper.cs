using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controllers.Damage.Overlap
{
    public class DamageBoxOverlapper : DamageOverlapper<BoxCollider2D>
    {
        #region Constructors

        public DamageBoxOverlapper(Transform gameObjectTransform, BoxCollider2D collider, LayerMask damageLayerMask) : base(gameObjectTransform, collider, damageLayerMask) { }

        #endregion

        #region Base Methods

        public override List<GameObject> Overlap()
        {
            return Physics2D
                    .OverlapBoxAll(_gameObjectTransform.position, _collider.size, _gameObjectTransform.rotation.z, _damageLayerMask)
                    .ToList()
                    .Select(x => x.gameObject)
                    .ToList();
        }

        #endregion
    }
}