// InputAxisAttribute.cs
// 07-20-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Displays a dropdown list of available Input Axis. (must be used with a 'string' typed field).
    /// </summary>
    /// <remarks>For Use only with the legacy Input System.</remarks>
    #if ENABLE_LEGACY_INPUT_MANAGER
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    #endif
    public class InputAxisAttribute : PropertyAttribute { }
}