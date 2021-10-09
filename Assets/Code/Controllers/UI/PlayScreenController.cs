using UnityEngine;
using Constants;
using Views.Components.UI;

using Object = UnityEngine.Object;

namespace Controllers.UI
{
    public class PlayScreenController : BaseUIController
    {

        #region Fields

        private GameObject _screen;

        private InscriptionUIController _pointsUIController;
        
        #endregion

        #region Constructors

        public PlayScreenController(GameObject prefab, RectTransform userInterfaceTransform, PointsController pointsController)
        {

            _screen = Object.Instantiate(prefab, userInterfaceTransform);

            CreatePointsUIController(pointsController);

        }

        #endregion

        #region Methods

        private void CreatePointsUIController(PointsController pointsController)
        {

            if (!_screen.TryGetComponent<PlayScreenView>(out var playScreenView))
            {

                throw new MissingComponentException(ErrorMessages.MissingComponentException(this.GetType(), typeof(PlayScreenView)));

            };

            _pointsUIController = new InscriptionUIController(playScreenView.PointsView.Points);

            pointsController.AddPointsHandler(x => _pointsUIController.Text = x);

        }

        #endregion

        #region Base Methods

        public override void Disable()
        {

            _screen.SetActive(false);

        }

        public override void Enable()
        {

            _screen.SetActive(true);

        }

        #endregion

    }

}