#region Header
// ObjectExtensions.cs
#endregion

using CoreFramework.Settings;
using UnityEngine;

namespace CoreFramework.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Logs an informational message with optional context and calling method.
        /// </summary>
        /// <param name="context">The context within which the log should be displayed.</param>
        /// <param name="msg">The message to log.</param>
        /// <param name="debugInfo">Is this object showing it's debug info.</param>
        /// <param name="callingMethod">The optional calling method from which the log originates.</param>
        public static void Info(this Object context, string msg, bool debugInfo, string callingMethod = "")
        {
#if UNITY_EDITOR
            if (!CoreFrameWorkSettings.ShowDebug || !debugInfo) return;
#endif
            Info(context, msg, callingMethod);
        }

        /// <summary>
        /// Logs an informational message with optional context and calling method.
        /// </summary>
        /// <param name="context">The context within which the log should be displayed.</param>
        /// <param name="msg">The message to log.</param>
        /// <param name="callingMethod">The optional calling method from which the log originates.</param>
        private static void Info(this Object context, string msg, string callingMethod = "")
        {
#if UNITY_EDITOR || DEBUG
            msg = !string.IsNullOrWhiteSpace(callingMethod)
                ? $"<color=brown><i>{callingMethod}</i></color>- {msg}"
                : $"- {msg}";

            msg =
                $"<size={CoreFrameWorkSettings.InfoSize}><b>Info: <color=blue><i>{context.name}</i></color></b> {msg}</size>";

            Debug.Log(msg, context);
#endif
        }
        
        /// <summary>
        /// Logs a warning message with optional context and calling method.
        /// </summary>
        /// <param name="context">The context within which the log should be displayed.</param>
        /// <param name="msg">The message to log.</param>
        /// <param name="callingMethod">The optional calling method from which the log originates.</param>
        public static void Warn(this Object context, string msg, string callingMethod = "")
        {
#if UNITY_EDITOR || DEBUG
            if (!CoreFrameWorkSettings.ShowDebug) return;
#endif
#if UNITY_EDITOR || DEBUG
            msg = !string.IsNullOrWhiteSpace(callingMethod)
                ? $"<color=olive><i>{callingMethod}</i></color>- {msg}"
                : $"- <color=yellow>{msg}</color>";

            msg =
                $"<size={CoreFrameWorkSettings.WarningSize}><b><color=orange>Warn:</color> " +
                $"<color=blue><i>{context.name}</i></color></b> {msg}</size>";

            Debug.LogWarning(msg, context);
#endif
        }
        
        /// <summary>
        /// Logs an error message with optional context and calling method.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        /// <param name="context">The context within which the log should be displayed.</param>
        /// <param name="callingMethod">The optional calling method from which the log originates.</param>
        public static void Error(this Object context, string msg, string callingMethod = "")
        {
            msg = !string.IsNullOrWhiteSpace(callingMethod)
                ? $"<color=purple><i>{callingMethod}</i></color>- {msg}"
                : $"- <color=red>{msg}</color>";

            msg =
                $"<size={CoreFrameWorkSettings.ErrorSize}><b><color=red>ERROR:</color> " +
                $"<color=maroon><i>{context.name}</i></color></b> {msg}</size>";

            Debug.LogError(msg, context);
        }
    }
}