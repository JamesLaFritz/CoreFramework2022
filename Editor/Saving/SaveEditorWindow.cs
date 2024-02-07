using System.Collections.Generic;
using System.IO;
using System.Linq;
using CoreFramework.Saving;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Screen;

namespace CoreFrameworkEditor.Saving
{
     /// <summary>
    /// A custom editor window
    /// <seealso href="https://docs.unity3d.com/ScriptReference/EditorWindow.html"/>
    /// </summary>
    public class SaveEditorWindow : EditorWindow
    {
        private const float WindowWidth = 400;
        private const float WindowHeight = 200;

        private const string HelpBoxText =
            "Every Save File has a Version Number. When trying to load a save, only files with the current version (or the minimum legacy version) will be valid.";

        private int _cachedVersionNumber;
        private int _cachedMinVersionNumber;
        private bool _legacySupport;
        private GUIStyle _centeredLabel;

        #region Window Managment

        [MenuItem("Window/Core Framework/Save Settings")]
        private static void ShowWindow()
        {
            SaveEditorWindow window = GetWindow<SaveEditorWindow>("Save Settings", true);

            //Set default size & position
            Rect windowRect = new Rect()
            {
                size = new Vector2(WindowWidth, WindowHeight),
                x = (float)currentResolution.width / 2 - WindowWidth,
                y = (float)currentResolution.height / 2 - WindowHeight
            };
            window.position = windowRect;

            window._legacySupport = VersionControl.MinFileVersion != VersionControl.CurrentFileVersion;
            window._cachedVersionNumber = VersionControl.CurrentFileVersion;
            window._cachedMinVersionNumber = VersionControl.MinFileVersion;

            window._centeredLabel = EditorStyles.boldLabel;
            window._centeredLabel.alignment = TextAnchor.MiddleCenter;
            window.Show();
        }

        /// <summary>
        /// <seealso href="https://docs.unity3d.com/ScriptReference/EditorWindow.OnGUI.html"/>
        /// </summary>
        private void OnGUI()
        {
            // Help Box
            EditorGUILayout.HelpBox(HelpBoxText, MessageType.Info);
            EditorGUILayout.Space();

            //Version Number Editing
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Current Version NR.", GUILayout.MaxWidth(150));
            if (_cachedVersionNumber == 1) GUI.enabled = false;
            if (GUILayout.Button("-", GUILayout.MaxWidth(25))) ShiftCurrentVersion(-1);
            if (!GUI.enabled) GUI.enabled = true;
            EditorGUILayout.LabelField($"{_cachedVersionNumber}", _centeredLabel, GUILayout.MaxWidth(35));
            if (GUILayout.Button("+", GUILayout.MaxWidth(25))) ShiftCurrentVersion(1);
            EditorGUILayout.EndHorizontal();

            // Legacy Version Number Editing
            _legacySupport = EditorGUILayout.Toggle("Backwards Compatibility", _legacySupport);
            if (_legacySupport)
            {
                if (_cachedMinVersionNumber > _cachedVersionNumber)
                {
                    _cachedMinVersionNumber = _cachedVersionNumber;
                }

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Min. Version NR.", GUILayout.MaxWidth(150));
                if (_cachedMinVersionNumber <= 1) GUI.enabled = false;
                if (GUILayout.Button("-", GUILayout.MaxWidth(25))) ShiftMinVersion(-1);
                if (!GUI.enabled) GUI.enabled = true;
                EditorGUILayout.LabelField($"{_cachedMinVersionNumber}", _centeredLabel, GUILayout.MaxWidth(35));
                if (_cachedMinVersionNumber >= _cachedVersionNumber) GUI.enabled = false;
                if (GUILayout.Button("+", GUILayout.MaxWidth(25))) ShiftMinVersion(1);
                if (!GUI.enabled) GUI.enabled = true;
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                _cachedMinVersionNumber = _cachedVersionNumber;
            }

            // Apply Changes
            if (_cachedVersionNumber == VersionControl.CurrentFileVersion &&
                _cachedMinVersionNumber == VersionControl.MinFileVersion)
            {
                GUI.enabled = false;
            }

            if (GUILayout.Button("Apply")) UpdateVersionNumber();
            if (!GUI.enabled) GUI.enabled = true;

            // Source Folder Access
            if (GUILayout.Button("Open Source Folder"))
                System.Diagnostics.Process.Start(GetSaveFolderPath()!);
        }

        #endregion

        #region Version Number Management

        private void ShiftCurrentVersion(int increment)
        {
            _cachedVersionNumber += increment;

            if (!_legacySupport)
            {
                _cachedMinVersionNumber = _cachedVersionNumber;
            }
        }

        private void ShiftMinVersion(int increment)
        {
            _cachedMinVersionNumber += increment;
        }

        private void UpdateVersionNumber()
        {
            VersionControl.CurrentFileVersion = _cachedVersionNumber;
            VersionControl.MinFileVersion = _cachedMinVersionNumber;

            IEnumerable<string> files = Directory.EnumerateFiles(
                    Directory.GetCurrentDirectory(), "VersionControl.cs", SearchOption.AllDirectories)
                .Where(f => File.ReadAllText(f).Contains("namespace CoreFramework.Saving"));

            foreach (var file in files)
            {
                if (!File.Exists(file)) continue;
                
                //HARDCODED VERSION UPDATE (Ugly but saves playing around with reading text files)
                string[] code =
                {
                    "namespace CoreFramework.Saving",
                    "{",
                    "\tpublic static class VersionControl",
                    "\t{",
                    $"\t\tpublic static int CurrentFileVersion = {_cachedVersionNumber};",
                    $"\t\tpublic static int MinFileVersion = {_cachedMinVersionNumber};",
                    "\t}",
                    "}"
                };
                
                File.WriteAllLines(file, code);
            }
        }

        #endregion

        #region Path Management

        private static string GetSaveFolderPath()
        {
            var basePath = SavingStrategy.BasePath;

            if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath!);

            return basePath;
        }

        #endregion
    }
}