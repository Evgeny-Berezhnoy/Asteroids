﻿using UnityEngine;
using Interfaces;

namespace Models
{
    public static class ResourcesLoader
    {
        #region Methods

        public static T LoadObject<T>(string objectDirectory)
            where T : Object
        {
            T objectInstance = null;

            return GetObject(ref objectInstance, objectDirectory);
        }

        public static T GetObject<T>(ref T objectInstance, string objectDirectory)
            where T : Object
        {
            if (!objectInstance)
            {
                InitializeObject(ref objectInstance, objectDirectory);
            };

            return objectInstance;
        }

        public static void InitializeObject<T>(ref T objectInstance, string objectDirectory)
            where T : Object
        {
            if (!string.IsNullOrEmpty(objectDirectory))
            {
                objectInstance = Resources.Load<T>(objectDirectory);

                if (objectInstance is IInitialize initializeInstance)
                {
                    initializeInstance.Initialize();
                };
            };
        }

        #endregion
    }
}