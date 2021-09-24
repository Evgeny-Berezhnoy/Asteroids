using UnityEngine;
using Initializers;
using Models.ScriptableObjects;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {

        #region Fields

        private ControllersList _controllersList;

        #endregion

        #region Properties

        [SerializeField] public GameConfiguration Configuration;

        #endregion

        #region Events

        public void Start()
        {

            _controllersList = new ControllersList();

            new GameInitializer(Configuration, _controllersList, transform);

        }

        public void Update()
        {

            _controllersList.OnUpdate(Time.deltaTime);

        }

        #endregion


    }

}
