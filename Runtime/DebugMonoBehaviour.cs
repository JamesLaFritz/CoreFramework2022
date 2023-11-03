﻿using CoreFramework.Settings;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoreFramework
{
    public class DebugMonoBehaviour : MonoBehaviour
    {
        [SerializeField] private bool _showDebugInfo = true;

        protected void Info(string msg, string callingMethod = "")
        {
#if UNITY_EDITOR
            if (!CoreFrameWorkSettings.ShowDebug || !_showDebugInfo) return;
#endif
            Log.Info(msg, gameObject, callingMethod);
        }

        protected void Warning(string msg, string callingMethod = "")
        {
#if UNITY_EDITOR
            if (!CoreFrameWorkSettings.ShowDebug) return;
#endif

            Log.Warn(msg, gameObject, callingMethod);
        }

        protected void Error(string msg, string callingMethod = "")
        {
            Log.Error(msg, gameObject, callingMethod);
        }
    }
}