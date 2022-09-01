// HeaderAttributeDecoratorDrawer.cs
// 07-20-2022
// James LaFritz

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using HeaderAttribute = CoreFramework.Attributes.HeaderAttribute;

namespace CoreFrameworkEditor.Attributes
{
    /// <summary>
    /// The header attribute decorator drawer class
    /// <seealso href="https://docs.unity3d.com/ScriptReference/DecoratorDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(HeaderAttribute))]
    public class HeaderAttributeDecoratorDrawer : DecoratorDrawer
    {
        /// <summary>
        /// The gray
        /// </summary>
        private Color _headerRectColor = Color.gray;

        /// <summary>
        /// The white
        /// </summary>
        private Color _color = Color.white;

        #region Overrides of DecoratorDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position)
        {
            if (!(attribute is HeaderAttribute headerAttribute)) return;

            position = EditorGUI.IndentedRect(position);
            position.yMin += EditorGUIUtility.singleLineHeight * (headerAttribute.TextHeightIncrease - 0.5f);

            if (!headerAttribute.ColorIsNull)
            {
                Debug.Assert(headerAttribute.Color != null, "headerAttribute.color != null");
                _headerRectColor = _color = (Color)headerAttribute.Color;
            }

            if (headerAttribute.HeaderIsNull && headerAttribute.IconPathIsNull)
            {
                position.height = headerAttribute.TextHeightIncrease;
                EditorGUI.DrawRect(position, _headerRectColor);
                return;
            }

            GUIStyle style = new GUIStyle(EditorStyles.boldLabel)
            {
                richText = true,
                normal =
                {
                    textColor = _color
                }
            };
            GUIContent label = new GUIContent(
                $"<size={style.fontSize + headerAttribute.TextHeightIncrease}><b>{headerAttribute.Header}</b></size>");
            if (!headerAttribute.IconPathIsNull)
            {
                label.image = EditorGUIUtility.Load(headerAttribute.IconPath) as Texture2D;
            }

            Vector2 textSize = style.CalcSize(label);
            float labelWidth = textSize.x;
            if (!headerAttribute.IconPathIsNull)
                labelWidth += position.height - 12.5f;

            float separatorWidth = (position.width - labelWidth) / 2.0f;

            Rect prefixRect = new Rect(position.xMin - 5f, position.yMin + 3f, separatorWidth,
                                       headerAttribute.TextHeightIncrease);
            Rect labelRect = new Rect(position.xMin + separatorWidth, position.yMin - 3f, labelWidth, position.height);
            Rect postRect = new Rect(position.xMin + separatorWidth + 3f + labelRect.width, position.yMin + 5f,
                                     separatorWidth - 10, headerAttribute.TextHeightIncrease);
            EditorGUI.DrawRect(prefixRect, _headerRectColor);
            EditorGUI.LabelField(labelRect, label, style);
            EditorGUI.DrawRect(postRect, _headerRectColor);
        }

        /// <inheritdoc />
        public override float GetHeight()
        {
            HeaderAttribute headerAttribute = attribute as HeaderAttribute;
            return EditorGUIUtility.singleLineHeight * (headerAttribute?.TextHeightIncrease + 0.25f ?? 1.5f);
        }

        #endregion

        public static VisualElement CreatePropertyGUI(HeaderAttribute attribute)
        {
            if (attribute == null) return null;
            Color headerRectColor = Color.gray;
            Color color = Color.white;

            if (!attribute.ColorIsNull)
            {
                Debug.Assert(attribute.Color != null, "headerAttribute.color != null");
                headerRectColor = color = (Color)attribute.Color;
            }

            VisualElement container = new VisualElement
            {
                name = "header",
                style =
                {
                    alignItems = Align.Center,
                    flexDirection = FlexDirection.Row,
                    flexGrow = 1
                }
            };
            container.Add(CreateBox(attribute.TextHeightIncrease, headerRectColor));

            if (attribute.HeaderIsNull && attribute.IconPathIsNull) return container;

            if (!attribute.IconPathIsNull)
            {
                Image image = new Image
                {
                    image = EditorGUIUtility.Load(attribute.IconPath) as Texture2D,
                    scaleMode = ScaleMode.ScaleToFit
                };
                container.Add(image);
            }

            if (!attribute.HeaderIsNull)
            {
                Label label = new Label
                {
                    text = attribute.Header,
                    name = "header-text",
                    style =
                    {
                        fontSize = 12 * attribute.TextHeightIncrease,
                        color = color
                    }
                };
                container.Add(label);
            }

            container.Add(CreateBox(attribute.TextHeightIncrease, headerRectColor));

            return container;
        }

        private static Box CreateBox(float height, Color headerRectColor)
        {
            Box box = new Box
            {
                name = "header-box",
                style =
                {
                    height = height,
                    flexGrow = 1,
                    color = headerRectColor,
                    backgroundColor = headerRectColor
                }
            };
            return box;
        }
    }
}