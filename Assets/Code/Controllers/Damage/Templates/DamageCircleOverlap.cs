using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controllers.Damage.Overlap
{
    public class DamageCircleOverlapper : DamageOverlapper<CircleCollider2D>
    {
        #region Constructors

        public DamageCircleOverlapper(Transform gameObjectTransform, CircleCollider2D collider, LayerMask damageLayerMask) : base(gameObjectTransform, collider, damageLayerMask) { }

        #endregion

        #region Base Methods

        public override List<GameObject> Overlap()
        {
            return Physics2D
                    .OverlapCircleAll(_gameObjectTransform.position, _collider.radius, _damageLayerMask)
                    .ToList()
                    .Select(x => x.gameObject)
                    .ToList();
        }

        #endregion
    }
}