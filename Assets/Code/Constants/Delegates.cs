using UnityEngine;

namespace Constants
{
    public static class Delegates
    {
        #region Delegates

        public delegate void AxisShiftDelegate(Vector3 axisShift, float deltaTime);
        public delegate void WheelScrollDelegate(Vector2 wheelScroll);
        public delegate void AudioTriggerDelegate(string audiotrackName, string audioType);

        #endregion
    }
}