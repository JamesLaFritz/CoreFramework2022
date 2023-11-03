using CoreFramework.Settings;
using UnityEngine;

namespace CoreFramework
{
    public static class Log
    {
        public static void Info(string msg, Object context, string callingMethod = "")
        {
            msg = !string.IsNullOrWhiteSpace(callingMethod)
                ? $"<color=brown><i>{callingMethod}</i></color>- {msg}"
                : $"- {msg}";

            msg =
                $"<size={CoreFrameWorkSettings.InfoSize}><b>Info: <color=blue><i>{context.name}</i></color></b> {msg}</size>";

            Debug.Log(msg, context);
        }
        
        public static void Warn(string msg, Object context, string callingMethod = "")
        {
            msg = !string.IsNullOrWhiteSpace(callingMethod)
                ? $"<color=olive><i>{callingMethod}</i></color>- {msg}"
                : $"- <color=yellow>{msg}</color>";

            msg =
                $"<size={CoreFrameWorkSettings.WarningSize}><b><color=orange>Warn:</color> " +
                $"<color=blue><i>{context.name}</i></color></b> {msg}</size>";

            Debug.LogWarning(msg, context);
        }
        
        public static void Error(string msg, Object context, string callingMethod = "")
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