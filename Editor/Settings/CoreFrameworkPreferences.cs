#region Header
// CoreFrameworkSettingSO.cs
// ktmar
#endregion

using CoreFramework.Settings;
using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Settings
{
    [FilePath("CoreFrameworkPreferences.asset", FilePathAttribute.Location.PreferencesFolder)]
    public class CoreFrameworkPreferences : ScriptableSingleton<CoreFrameworkPreferences>
    {
        #region Fields

        /// <summary>
        /// A flag indicating whether debugging logs should be shown.
        /// </summary>
        [SerializeField] private bool _showDebug = true;

        /// <summary>
        /// The font size for informational log messages.
        /// </summary>
        [SerializeField] private int _infoSize = 14;

        /// <summary>
        /// The font size for warning log messages.
        /// </summary>
        [SerializeField] private int _warningSize = 15;

        /// <summary>
        /// The font size for error log messages.
        /// </summary>
        [SerializeField] private int _errorSize = 16;

        #endregion

        #region Properties

        /// <summary>
        /// A flag indicating whether debugging logs should be shown.
        /// </summary>
        public bool ShowDebug
        {
            get => _showDebug;
            set
            {
                _showDebug = value;
                CoreFrameWorkSettings.ShowDebug = value;
                Save(true);
            }
        }

        /// <summary>
        /// The font size for informational log messages.
        /// </summary>
        public int InfoSize
        {
            get => _infoSize;
            set
            {
                _infoSize = value;
                Save(true);
            }
        }

        /// <summary>
        /// The font size for warning log messages.
        /// </summary>
        public int WarningSize
        {
            get => _warningSize;
            set
            {
                _warningSize = value;
                Save(true);
            }
        }

        /// <summary>
        /// The font size for error log messages.
        /// </summary>
        public int ErrorSize
        {
            get => _errorSize;
            set
            {
                _errorSize = value;
                Save(true);
            }
        }

        #endregion
    }
}