// SceneAttribute.cs
// 07-20-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes.Properties.DropDownSelection
{
    /// <summary>
    /// Displays a dropdown list of available build settings Scenes (must be used with a 'string' or 'integer' typed field).
    /// <example>
    /// <code>
    /// [Scene] public string sceneString;
    /// [Scene] public int sceneInt;
    /// </code>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SceneAttribute : PropertyAttribute { }
}