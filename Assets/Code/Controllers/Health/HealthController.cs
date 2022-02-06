using UnityEngine;
using Interfaces;

namespace Controllers.Health
{
    public class HealthController : IHealthController
    {
        #region Fields

        protected int _health;
        protected int _healthCapacity;

        #endregion

        #region Interfaces properties

        public int Health { get => _health; }
        public int HealthCapacity { get => _healthCapacity; set => _healthCapacity = value; }
        public bool IsDead => (_health == 0);

        #endregion

        #region Constructors

        public HealthController(int healthCapacity)
        {
            _healthCapacity = healthCapacity;
            _health         = healthCapacity;
        }

        #endregion

        #region Interfaces Methods

        public void Damage(int damage)  => ChangeHealth(0 - damage);
        public void Heal(int heal)      => ChangeHealth(heal);
        public void Resurect()          => _health = _healthCapacity;

        #endregion

        #region Methods

        protected void ChangeHealth(int value)
        {
            _health += value;

            _health = Mathf.Clamp(_health, 0, _healthCapacity);
        }

        #endregion
    }
}