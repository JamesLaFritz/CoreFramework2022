using UnityEngine;

namespace CoreFramework
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
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