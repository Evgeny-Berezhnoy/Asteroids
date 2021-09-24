using System;

namespace Constants
{
    public static class ErrorMessages
    {

        public static readonly string SHOOTER_MODELS_NOT_TRANSFERED = "Shooter models weren't transfered to Shooter Swapper.";

        public static string SpawnableObjectCreate(string spawnableObjectName)
        {

            return $"Can't create spawnable object {spawnableObjectName}. Pool space hasn't been instantiated.";

        }

        public static string SpawnableObjectDestroy(string spawnableObjectName)
        {

            return $"Can't destroy spawnable object {spawnableObjectName}. Pool space hasn't been instantiated.";

        }

        public static string MissingComponentException(Type constructableClass, Type componentClass)
        {

            return $"Failed to construct class {constructableClass.Name}. Prefab doesn't have component of {componentClass.Name}";

        }

        public static string NumbericIsEmpty(Type constructableClass, string variableName)
        {

            return $"Failed to construct class {constructableClass.Name}. {variableName} hasn't been determined.";

        }

    }

}