using UnityEngine;
using Initializers;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private string _configuration;
        [SerializeField] private RectTransform _userInterfaceTransform;
        [SerializeField] private Transform _audio;
        
        private ControllersList _controllersList;

        #endregion

        #region Unity events

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