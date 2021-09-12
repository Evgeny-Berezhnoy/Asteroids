namespace Interfaces
{
    public interface IHealthController
    {

        #region Properties

        int Health { get; }
        int HealthCapacity { get; set; }

        bool IsDead { get; }

        #endregion

        #region Methods

        void Damage(int damage);

        void Heal(int heal);

        void Resurect();

        #endregion

    }

}
