using System;

namespace Constants
{
    public static class ErrorMessages
    {

        public static readonly string SHOOTER_MODELS_NOT_TRANSFERED = "Shooter models weren't transfered to Shooter Swapper.";

        public static string InvalidAudioType(string audioType)
        {

            return $"Invalid audio type has been transfered. There isn't definition for \"{audioType}\".";

        }
        
        public static string MissingAudio(string audioType)
        {

            return $"Audio sample of type {audioType} is missing.";

        }

        public static string MissingAudio(string audiotrackName, string audioType)
        {

            return $"Audio sample {audiotrackName} of type {audioType} is missing.";
            
        }

        public static string MissingComponentException(Type constructableClass, Type componentClass)
        {

            return $"Failed to construct class {constructableClass.Name}. Prefab doesn't have component of {componentClass.Name}";

        }

        public static string MissingConfiguration(string configurationDirectory)
        {

            return $"Configuration at {configurationDirectory} directory has not been found.";

        }
        
        public static string NumbericIsEmpty(Type constructableClass, string variableName)
        {

            return $"Failed to construct class {constructableClass.Name}. {variableName} hasn't been determined.";

        }

        public static string RepeatingSample(string audiotrackName, string audioType)
        {

            return $"There already is audio sample {audiotrackName} of type {audioType} in music strorage.";
            
        }

        public static string SpawnableObjectCreate(string spawnableObjectName)
        {

            return $"Can't create spawnable object {spawnableObjectName}. Pool space hasn't been instantiated.";

        }

        public static string SpawnableObjectDestroy(string spawnableObjectName)
        {

            return $"Can't destroy spawnable object {spawnableObjectName}. Pool space hasn't been instantiated.";

        }

    }

}