using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class InscriptionUIController : BaseUIController
    {

        #region Fields

        private GameObject _gameObject;
        private Text _inscription;

        #endregion

        #region Properties

        public string Text { get => _inscription.text; set => _inscription.text = value; }

        #endregion

        #region Constructors

        public InscriptionUIController(Text inscription)
        {
            _inscription    = inscription;
            _gameObject     = inscription.gameObject;   
        }

        #endregion

        #region Base Methods

        public override void Enable() => _gameObject.SetActive(true);
        public override void Disable() => _gameObject.SetActive(false);

        #endregion
    }
}