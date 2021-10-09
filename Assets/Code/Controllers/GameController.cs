using UnityEngine;
using Initializers;
using Models.ScriptableObjects;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {

        #region Fields

        private ControllersList _controllersList;

        [SerializeField] private string _configuration;
        [SerializeField] private RectTransform _userInterfaceTransform;
        [SerializeField] private Transform _audio;

        #endregion

        #region Events

        public void Start()
        {

            _controllersList = new ControllersList();

            new GameInitializer(_configuration, _controllersList, transform, _userInterfaceTransform, _audio);

        }

        public void Update()
        {

            _controllersList.OnUpdate(Time.deltaTime);

        }

        #endregion


    }

}