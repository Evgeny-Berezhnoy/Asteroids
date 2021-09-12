using UnityEngine;
using Constants;
using ExtensionCompilation;
using Views.Templates;


namespace Models.Constructables
{

    public class ScreenMapModel
    {

        #region Properties

        public Transform ModelTransform;
        public Transform PlayerStartTransform;
        public Transform EnemiesRoutesTransform;
        public RouteContainer EnemiesRoutesContainer;

        #endregion

        #region Constructors

        public ScreenMapModel(Transform rootTransform)
        {

            ModelTransform = new GameObject(GameobjectNames.SCREEN_MAP_MODEL).transform;
            ModelTransform.SetParent(rootTransform);
            ModelTransform.SetLocalPositionAndRotation();

            PlayerStartTransform = new GameObject(GameobjectNames.PLAYER_START_POINT).transform;
            PlayerStartTransform.SetParent(ModelTransform);

            EnemiesRoutesTransform = new GameObject(GameobjectNames.ENEMY_ROUTES).transform;
            EnemiesRoutesTransform.SetParent(ModelTransform);
            EnemiesRoutesTransform.SetLocalPositionAndRotation();
            
            EnemiesRoutesContainer = new RouteContainer();

        }

        #endregion

    }

}