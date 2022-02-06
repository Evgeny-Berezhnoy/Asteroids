namespace Controllers.Health
{
    public class PlayerHealthController : HealthController
    {
        #region Constructors

        public PlayerHealthController(int healthCapacity) : base(healthCapacity) { }

        #endregion
    }
}