// InfoBoxDecoratorDrawer.cs
// 07-20-2022
// James LaFritz

using CoreFramework.Attributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes
{
    /// <summary>
    /// The info box decorator drawer class
    /// <seealso href="https://docs.unity3d.com/ScriptReference/DecoratorDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(InfoBoxAttribute))]
    public class InfoBoxDecoratorDrawer : DecoratorDrawer
    {
        private const int KLineHeight = 13;
        private const string KInfoClass = "unity-info-box-info";
        private const string KWarnClass = "unity-info-box-warn";
        private const string KErrorClass = "unity-info-box-error";

        #region Overrides of DecoratorDrawer

        /// <inheritdoc />
        public override float GetHeight()
        {
            return GetHeight((InfoBoxAttribute)attribute);
        }

        /// <inheritdoc />
        public override void OnGUI(Rect position)
        {
            if (!(attribute is InfoBoxAttribute infoBoxAttribute)) return;

            Rect indentRect = EditorGUI.IndentedRect(position);
            float indentLength = indentRect.x - position.x;
            Rect infoBoxRect = new Rect(
                position.x + indentLength,
                position.y,
                position.width - indentLength,
                GetHeight(infoBoxAttribute));

            DrawInfoBox(infoBoxRect, infoBoxAttribute.text, infoBoxAttribute.infoBoxType);
        }

        #endregion

        private static float GetHeight(InfoBoxAttribute attribute)
        {
            float minHeight = EditorGUIUtility.singleLineHeight * 2.0f;
            float desiredHeight =
                GUI.skin.box.CalcHeight(new GUIContent(attribute.text), EditorGUIUtility.currentViewWidth);
            float height = Mathf.Max(minHeight, desiredHeight);

            return height;
        }

        public static VisualElement CreatePropertyGUI(InfoBoxAttribute attribute)
        {
            if (attribute == null) return null;

            Box container = new Box()
            {
                name = "unity-info-box"
            };
            container.styleSheets.Add(Resources.Load<StyleSheet>("InfoBoxStyles"));

            Box titleContainer = new Box()
            {
                name = "unity-info-box-title-container",
                style =
                {
                    flexDirection = FlexDirection.Row
                }
            };
            Label title = new Label()
            {
                name = "unity-info-box-title"
            };
            Image titleIcon = new Image()
            {
                name = "unity-info-box-icon"
            };
            titleContainer.Add(titleIcon);
            titleContainer.Add(title);
            container.Add(titleContainer);

            Label message = new Label()
            {
                name = "unity-info-box-message",
                text = attribute.text,
                // style =
                // {
                //     minHeight = GetHeight(attribute),
                // }
            };
            container.Add(message);

            switch (attribute.infoBoxType)
            {
                case InfoBoxType.Info:
                    titleIcon.image = EditorGUIUtility.IconContent("d_console.infoicon.sml").image;
                    title.text = "Info";
                    container.AddToClassList(KInfoClass);
                    titleContainer.AddToClassList(KInfoClass);
                    title.AddToClassList(KInfoClass);
                    titleIcon.AddToClassList(KInfoClass);
                    message.AddToClassList(KInfoClass);
                    break;
                case InfoBoxType.Warning:
                    titleIcon.image = EditorGUIUtility.IconContent("d_console.warnicon.sml").image;
                    title.text = "Warning";
                    container.AddToClassList(KWarnClass);
                    titleContainer.AddToClassList(KWarnClass);
                    title.AddToClassList(KWarnClass);
                    titleIcon.AddToClassList(KWarnClass);
                    message.AddToClassList(KWarnClass);
                    break;
                case InfoBoxType.Error:
                    titleIcon.image = EditorGUIUtility.IconContent("d_console.erroricon.sml").image;
                    title.text = "Error";
                    container.AddToClassList(KErrorClass);
                    titleContainer.AddToClassList(KErrorClass);
                    title.AddToClassList(KErrorClass);
                    titleIcon.AddToClassList(KErrorClass);
                    message.AddToClassList(KErrorClass);
                    break;
                case InfoBoxType.None:
                    break;
            }

            return container;
        }

        /// <summary>
        /// Draws the info box using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="infoText">The info text</param>
        /// <param name="infoBoxType">The info box type</param>
        private void DrawInfoBox(Rect position, string infoText, InfoBoxType infoBoxType)
        {
            MessageType messageType = infoBoxType switch
            {
                InfoBoxType.Info => MessageType.Info,
                InfoBoxType.Warning => MessageType.Warning,
                InfoBoxType.Error => MessageType.Error,
                _ => MessageType.None
            };

            EditorGUI.HelpBox(position, infoText, messageType);
        }
    }
}