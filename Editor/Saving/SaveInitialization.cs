#region Header
// SaveInitialization.cs
// Author: James LaFritz
// Description: Initializes save-related settings upon the editor's load, ensuring consistency with project settings.
// This class sets the current and minimum save file versions, checks and updates the PlayerSettings bundle version.
#endregion

using System;
using CoreFramework.Saving;
using UnityEditor;

namespace CoreFrameworkEditor.Saving
{
    /// <summary>
    /// Handles the initialization of save-related settings upon the editor's load.
    /// </summary>
    [InitializeOnLoad]
    public static class SaveInitialization
    {
        static SaveInitialization()
        {
            // Retrieve the SaveProjectSettings instance
            var settings = SaveProjectSettings.instance;

            // Set the current and minimum save file versions from the SaveProjectSettings
            VersionControl.CurrentFileVersion = settings.CurrentFileVersion;
            VersionControl.MinFileVersion = settings.MinFileVersion;

            // Check if the PlayerSettings bundle version can be parsed as a Version
            if (Version.TryParse(PlayerSettings.bundleVersion, out var result) && VersionControl.CurrentFileVersion < result)
                // If successful and the parsed version is newer, update the current save file version
                settings.CurrentFileVersion = result;
            else
                // Otherwise, set the PlayerSettings bundle version to the current save file version
                PlayerSettings.bundleVersion = settings.CurrentFileVersion.ToString();
        }
    }
}