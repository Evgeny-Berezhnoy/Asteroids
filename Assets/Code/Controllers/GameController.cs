using UnityEngine;
using Initializers;
using Models.ScriptableObjects;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {

        #region Fields

        private ControllersList _controllersList;

        [SerializeField] private GameConfiguration _configuration;
        [SerializeField] private RectTransform userInterfaceTransform;

        #endregion

        #region Events

        public void Start()
        {

            _controllersList = new ControllersList();

            new GameInitializer(_configuration, _controllersList, transform, userInterfaceTransform);

        }

        public void Update()
        {

            _controllersList.OnUpdate(Time.deltaTime);

        }

        #endregion


    }

}