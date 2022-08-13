// ButtonAttribute.cs
// 07-19-2022
// James LaFritz

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Put this attribute above one of your MonoBehaviour method and it will draw
    /// a button in the inspector automatically.
    /// <remarks>The method must not have any params and can not be static.</remarks>
    /// <example>
    /// <code>
    /// [Button]
    /// public void MyMethod()
    /// {
    ///     Debug.Log($"{name}: MyMethod()");
    /// }
    /// </code>
    /// </example>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class ButtonAttribute : System.Attribute
    {
        /// <summary>
        /// The mode enum
        /// </summary>
        public enum Mode
        {
            /// <summary>
            /// The editor mode
            /// </summary>
            Editor,

            /// <summary>
            /// The play mode
            /// </summary>
            Play,

            /// <summary>
            /// Both Editor and Play Mode
            /// </summary>
            Both
        }

        /// <summary>
        /// The mode of the button.
        /// </summary>
        public readonly Mode mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonAttribute"/> class
        /// </summary>
        /// <param name="mode">The mode</param>
        public ButtonAttribute(Mode mode = Mode.Both)
        {
            this.mode = mode;
        }
    }
}