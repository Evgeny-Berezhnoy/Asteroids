using Interfaces;

namespace Controllers
{
    public class GameStateController : IController, IGameStatementListener
    {

        #region Fields

        public bool GameIsStopped { get; private set; }

        #endregion

        #region Constructors

        public GameStateController() 
        {

            StartGame();

        }

        #endregion

        #region Methods

        public void StartGame()
        {

            GameIsStopped = false;

        }

        public void StopGame()
        {

            GameIsStopped = true;

        }

        #endregion

    }

}
