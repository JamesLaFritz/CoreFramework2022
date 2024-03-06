#region Header
// SaveProjectSettings.cs
// Author: James LaFritz
// Manages project-specific settings related to save file versions and backward compatibility.
// Handles serialization of version information and provides functionality to update these settings.
// This scriptable object is intended to be used as a singleton through the SaveProjectSettings.instance property.
// FilePath attribute specifies the location of the serialized asset in the ProjectFolder.
#endregion

using System;
using CoreFramework.Saving;
using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Saving
{
    /// <summary>
    /// Represents the project settings for managing save file versions and backward compatibility.
    /// </summary>
    [FilePath("ProjectSettings/SaveProjectSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class SaveProjectSettings : ScriptableSingleton<SaveProjectSettings>
    {
        #region Version

        /// <summary>
        /// The major version component of the current save file format.
        /// </summary>
        [SerializeField] private int _major;

        /// <summary>
        /// The minor version component of the current save file format.
        /// </summary>
        [SerializeField] private int _minor;

        /// <summary>
        /// The build version component of the current save file format.
        /// </summary>
        [SerializeField] private int _build;

        /// <summary>
        /// The revision version component of the current save file format.
        /// </summary>
        [SerializeField] private int _revision = 1;

        /// <summary>
        /// Represents the latest version of the save file format. This should be incremented whenever 
        /// there's a change in the structure or data stored in save files.
        /// </summary>
        public Version CurrentFileVersion
        {
            get => new Version(_major, _minor, _build, _revision);
            set
            {
                PlayerSettings.bundleVersion = value.ToString();
                VersionControl.CurrentFileVersion = value;
                _major = value.Major;
                _minor = value.Minor;
                _build = value.Build;
                _revision = value.Revision;
                Save(true);
            }
        }

        #endregion

        #region Min Version

        // Serialization fields for the minimum supported save file version
        /// <summary>
        /// The major version component of the minimum supported save file format.
        /// </summary>
        [SerializeField] private int _minMajor;

        /// <summary>
        /// The minor version component of the minimum supported save file format.
        /// </summary>
        [SerializeField] private int _minMinor;

        /// <summary>
        /// The build version component of the minimum supported save file format.
        /// </summary>
        [SerializeField] private int _minBuild;

        /// <summary>
        /// The revision version component of the minimum supported save file format.
        /// </summary>
        [SerializeField] private int _minRevision;

        /// <summary>
        /// Denotes the earliest version of the save file that the game still supports. This allows the game 
        /// to handle older save files by potentially migrating or upgrading them to the current format.
        /// </summary>
        public Version MinFileVersion
        {
            get => new Version(_minMajor, _minMinor, _minBuild, _minRevision);
            set
            {
                VersionControl.MinFileVersion = value;
                _minMajor = value.Major;
                _minMinor = value.Minor;
                _minBuild = value.Build;
                _minRevision = value.Revision;
                Save(true);
            }
        }

        #endregion
    }
}