using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Controllers.Damage.Overlap
{
    public abstract class DamageOverlapper<T> : IOverlapper
        where T : Collider2D
    {

        #region Fields

        protected Transform _gameObjectTransform;
        protected T _collider;
        protected LayerMask _damageLayerMask;

        #endregion

        #region Constructors

        public DamageOverlapper(Transform gameObjectTransform, T collider, LayerMask damageLayerMask)
        {

            _gameObjectTransform    = gameObjectTransform;
            _collider               = collider;
            _damageLayerMask        = damageLayerMask;

        }

        #endregion

        #region Methods

        public abstract List<GameObject> Overlap();

        #endregion


    }

}