// ButtonAttributeHelper.cs
// 07-19-2022
// James LaFritz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CoreFramework.Attributes;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace CoreFrameworkEditor.Inspector
{
    /// <summary>
    /// Searches through a target class in order to find all button attributes (<see cref="ButtonAttribute"/>/>).
    /// </summary>
    public sealed class ButtonAttributeHelper
    {
        /// <summary>
        /// The empty param list
        /// </summary>
        private static readonly object[] EmptyParamList = Array.Empty<object>();


        /// <summary>
        /// The target Object
        /// </summary>
        private Object _targetObject;

        /// <summary>
        /// The method info
        /// </summary>
        private IList<MethodInfo> _methodInfos = new List<MethodInfo>();

        /// <summary>
        /// The button attribute
        /// </summary>
        private IDictionary<MethodInfo, ButtonAttribute> _buttonAttributes =
            new Dictionary<MethodInfo, ButtonAttribute>();

        /// <summary>
        /// Inits the target object
        /// </summary>
        /// <param name="targetObject">The target object</param>
        public void Init(Object targetObject)
        {
            _targetObject = targetObject;
            _methodInfos = GetMethods(targetObject, out _buttonAttributes);
        }

        /// <summary>
        /// Draws the buttons
        /// </summary>
        public void DrawButtons()
        {
            if (_methodInfos?.Count > 0)
            {
                DrawMethodButtons();
            }
        }

        /// <summary>
        /// Creates the button visual elements.
        /// </summary>
        /// <returns>A Visual Element representing the Buttons.</returns>
        public VisualElement CreateButtons()
        {
            return _methodInfos?.Count > 0 ? CreateMethodButtons() : null;
        }

        /// <summary>
        /// Gets the methods using the specified target object
        /// </summary>
        /// <param name="targetObject">The target object</param>
        /// <param name="buttonAttributesDictionary">The button attributes dictionary</param>
        /// <returns>The methods</returns>
        private IList<MethodInfo> GetMethods(Object targetObject,
                                             out IDictionary<MethodInfo, ButtonAttribute> buttonAttributesDictionary)
        {
            IList<MethodInfo> methods = targetObject.GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m =>
                           m.GetCustomAttributes(typeof(ButtonAttribute), true).Length == 1 &&
                           m.GetParameters().Length == 0 && !m.ContainsGenericParameters
                ).ToList();

            buttonAttributesDictionary = new Dictionary<MethodInfo, ButtonAttribute>();
            foreach (MethodInfo method in methods)
            {
                ButtonAttribute attribute = new ButtonAttribute();
                object[] attributes = method.GetCustomAttributes(typeof(ButtonAttribute), true);
                if (attributes.Length > 0 && attributes[0] is ButtonAttribute)
                {
                    attribute = attributes[0] as ButtonAttribute;
                }

                buttonAttributesDictionary.Add(method, attribute);
            }

            return methods;
        }

        /// <summary>
        /// Draws the buttons in the Inspector GUI.
        /// </summary>
        private void DrawMethodButtons()
        {
            if (_methodInfos == null) return;
            if (_buttonAttributes == null || _buttonAttributes.Count != _methodInfos.Count) return;

            foreach (MethodInfo method in _methodInfos)
            {
                if (method == null) continue;

                bool disabled = IsDisabled(method);
                string buttonText = GetButtonText(method);

                using (new EditorGUI.DisabledGroupScope(disabled))
                {
                    DrawButton(buttonText, method);
                }
            }
        }

        private void DrawButton(string buttonText, [NotNull] MethodInfo method)
        {
            if (GUILayout.Button(buttonText))
            {
                OnButtonClick(method);
            }
        }

        private VisualElement CreateMethodButtons()
        {
            if (_methodInfos == null) return null;
            if (_buttonAttributes == null || _buttonAttributes.Count != _methodInfos.Count) return null;
            VisualElement buttons = new VisualElement();
            foreach (MethodInfo method in _methodInfos)
            {
                if (method == null) continue;

                bool disabled = IsDisabled(method);
                string buttonText = GetButtonText(method);
                VisualElement button = CreateButton(buttonText, method, disabled);
                buttons.Add(button);
            }

            return buttons;
        }

        private VisualElement CreateButton(string buttonText, [NotNull] MethodInfo method, bool disabled)
        {
            Button button = new Button(() => OnButtonClick(method))
            {
                text = buttonText
            };
            button.SetEnabled(!disabled);
            return button;
        }

        private bool IsDisabled([NotNull] MethodInfo method)
        {
            ButtonAttribute attribute = _buttonAttributes[method];
            if (attribute == null) return false;
            bool disabled = attribute.mode switch
            {
                ButtonAttribute.Mode.Editor => EditorApplication.isPlaying,
                ButtonAttribute.Mode.Play => !EditorApplication.isPlaying,
                _ => false
            };

            return disabled;
        }

        private static string GetButtonText([NotNull] MethodInfo method)
        {
            string buttonText = ObjectNames.NicifyVariableName(method.Name);
            return buttonText;
        }

        private void OnButtonClick([NotNull] MethodInfo method)
        {
            method.Invoke(_targetObject, EmptyParamList);
        }
    }
}