#region Header
// CoreFrameworkMenu.cs
// Author: James LaFritz
// Description: Provides a generic Singleton class for MonoBehaviour types. Ensures that only one instance of the MonoBehaviour exists within the application. If no instance is found, one will be created.
#endregion

using UnityEngine;

namespace CoreFramework
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    [HelpURL("https://jameslafritz.github.io/CoreFramework2022/Manual/Singleton.html")]
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBePrivate.Global
        protected static T instance;

        // ReSharper disable once MemberCanBePrivate.Global
        public static bool HasInstance => instance != null;
        public static T TryGetInstance() => HasInstance ? instance : null;
        public static T Current => instance;

        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = FindFirstObjectByType<T>();
                if (instance != null) return instance;
                var go = new GameObject
                {
                    name = typeof(T).Name + "AutoCreated"
                };
                instance = go.AddComponent<T>();

                return instance;
            }
        }

        protected virtual void Awake() => InitializeSingleton();

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying) return;
            instance = this as T;
        }
    }
}
