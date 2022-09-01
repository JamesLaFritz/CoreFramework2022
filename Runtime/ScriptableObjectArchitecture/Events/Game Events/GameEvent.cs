#region Description

// GameEvent.cs
// 09-21-2021
// James LaFritz

// ----------------------------------------------------------------------------
// Based on
//
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

#endregion

using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// A Game Event that has no arguments.
    /// </summary>
    [CreateAssetMenu(fileName = "GameEvent.asset", menuName = Utility.GameEvent + "Game Event", order = Utility.AssetMenuOrderEvents - 1)]
    public class GameEvent : BaseGameEvent { }
}