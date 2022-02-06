using System.Collections.Generic;
using UnityEngine;
using Constants;
using ExtensionCompilation;
using Models.Constructables.ConfigurationModels;

namespace Models.Constructables
{
    public class ShooterMapModel
    {
        #region Fields

        private Transform _rootTransform;

        #endregion

        #region Properties

        public Transform RootTransform => _rootTransform; 
        public List<Transform> ShootingPoints { get; private set; }

        #endregion

        #region Constructors

        public ShooterMapModel(Transform rootTransform, ShooterConfigurationModel shooterConfigurationModel) : this(rootTransform, shooterConfigurationModel.ShooterMap.ShootingPoints, shooterConfigurationModel.GameobjectName) { }

        public ShooterMapModel(Transform rootTransform, List<Transform> shootingPoints, string gunName)
        {
            _rootTransform = new GameObject(gunName).transform;
            _rootTransform.SetParent(rootTransform);
            _rootTransform.SetLocalPositionAndRotation();

            ShootingPoints = new List<Transform>();

            for (int i = 0; i < shootingPoints.Count; i++)
            {
                Transform muzzle = new GameObject(GameobjectNames.MUZZLE).transform;

                muzzle.SetParent(_rootTransform);
                muzzle.SetLocalPositionAndRotation(shootingPoints[i]);

                ShootingPoints.Add(muzzle);
            };
        }

        #endregion
    }
}