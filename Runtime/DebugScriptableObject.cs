using CoreFramework.Settings;
using UnityEngine;

namespace CoreFramework
{
    public abstract class DebugScriptableObject : ScriptableObject
    {
        [SerializeField] private bool _debugInfo = true;

        protected void Info(string msg, string callingMethod = "")
        {
#if UNITY_EDITOR
            if (!CoreFrameWorkSettings.ShowDebug || !_debugInfo) return;
#endif
            Log.Info(msg, this, callingMethod);
        }

        protected void Warning(string msg, string callingMethod = "")
        {
#if UNITY_EDITOR
            if (!CoreFrameWorkSettings.ShowDebug) return;
#endif

            Log.Warn(msg, this, callingMethod);
        }

        protected void Error(string msg, string callingMethod = "")
        {
            Log.Error(msg, this, callingMethod);
        }
    }
}