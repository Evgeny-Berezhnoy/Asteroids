using System;

namespace Constants
{
    public static class ErrorMessages
    {
        #region Static fields

        public static readonly string SHOOTER_MODELS_NOT_TRANSFERED = "Shooter models weren't transfered to Shooter Swapper.";

        #endregion

        #region Static methods

        public static string InvalidAudioType(string audioType)                                         => $"Invalid audio type has been transfered. There isn't definition for \"{audioType}\".";
        public static string MissingAudio(string audioType)                                             => $"Audio sample of type {audioType} is missing.";
        public static string MissingAudio(string audiotrackName, string audioType)                      => $"Audio sample {audiotrackName} of type {audioType} is missing.";
        public static string MissingComponentException(Type constructableClass, Type componentClass)    => $"Failed to construct class {constructableClass.Name}. Prefab doesn't have component of {componentClass.Name}";
        public static string MissingConfiguration(string configurationDirectory)                        => $"Configuration at {configurationDirectory} directory has not been found.";
        public static string NumbericIsEmpty(Type constructableClass, string variableName)              => $"Failed to construct class {constructableClass.Name}. {variableName} hasn't been determined.";
        public static string RepeatingSample(string audiotrackName, string audioType)                   => $"There already is audio sample {audiotrackName} of type {audioType} in music strorage.";
        public static string SpawnableObjectCreate(string spawnableObjectName)                          => $"Can't create spawnable object {spawnableObjectName}. Pool space hasn't been instantiated.";
        public static string SpawnableObjectDestroy(string spawnableObjectName)                         => $"Can't destroy spawnable object {spawnableObjectName}. Pool space hasn't been instantiated.";

        #endregion
    }
}