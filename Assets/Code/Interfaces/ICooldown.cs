namespace Interfaces
{

    public interface ICooldown
    {

        #region Properties

        float Cooldown { get; set; }
        float CurrentCooldown { get; set; }
        
        #endregion

    }

}
