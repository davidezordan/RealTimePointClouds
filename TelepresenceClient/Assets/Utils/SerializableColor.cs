using UnityEngine;
using System;

namespace Utils
{

    /// <summary>
    /// Since unity doesn't flag the Quaternion as serializable, we
    /// need to create our own version. This one will automatically convert
    /// between Quaternion and SerializableQuaternion
    /// </summary>
    [Serializable]
    public struct SerializableColor
    {
        /// <summary>
        /// r component
        /// </summary>
        public float r;

        /// <summary>
        /// g component
        /// </summary>
        public float g;

        /// <summary>
        /// b component
        /// </summary>
        public float b;

        /// <summary>
        /// a component
        /// </summary>
        public float a;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public SerializableColor(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        /// <summary>
        /// Returns a string representation of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}]", r, g, b, a);
        }

        /// <summary>
        /// Automatic conversion from SerializableColor to Color
        /// </summary>
        /// <param name="rValue"></param>
        /// <returns></returns>
        public static implicit operator Color(SerializableColor rValue)
        {
            return new Color(rValue.r, rValue.g, rValue.b, rValue.a);
        }

        /// <summary>
        /// Automatic conversion from Quaternion to SerializableColor
        /// </summary>
        /// <param name="rValue"></param>
        /// <returns></returns>
        public static implicit operator SerializableColor(Color rValue)
        {
            return new SerializableColor(rValue.r, rValue.g, rValue.b, rValue.a);
        }
    }
}