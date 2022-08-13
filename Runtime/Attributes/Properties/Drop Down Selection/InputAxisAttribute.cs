// InputAxisAttribute.cs
// 07-20-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes.Properties.DropDownSelection
{
    /// <summary>
    /// Displays a dropdown list of available Input Axis. (must be used with a 'string' typed field).
    /// <example>
    /// <code>
    /// [InputAxis] public string inputToUse;
    /// </code>
    /// <code>
    /// private void Update()
    /// {
    ///     float axis = Input.GetAxis(inputToUse);
    ///     bool buttonPressed = Input.GetButton(inputToUse);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <remarks>For Use only with the legacy Input System.</remarks>
    #if ENABLE_LEGACY_INPUT_MANAGER
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    #endif
    public class InputAxisAttribute : PropertyAttribute { }
}