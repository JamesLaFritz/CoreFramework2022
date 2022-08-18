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
        private Color m_headerRectColor = Color.gray;

        /// <summary>
        /// The white
        /// </summary>
        private Color m_color = Color.white;

        #region Overrides of DecoratorDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position)
        {
            if (!(attribute is HeaderAttribute headerAttribute)) return;

            position = EditorGUI.IndentedRect(position);
            position.yMin += EditorGUIUtility.singleLineHeight * (headerAttribute.textHeightIncrease - 0.5f);

            if (!headerAttribute.colorIsNull)
            {
                Debug.Assert(headerAttribute.color != null, "headerAttribute.color != null");
                m_headerRectColor = m_color = (Color)headerAttribute.color;
            }

            if (headerAttribute.headerIsNull && headerAttribute.iconPathIsNull)
            {
                position.height = headerAttribute.textHeightIncrease;
                EditorGUI.DrawRect(position, m_headerRectColor);
                return;
            }

            GUIStyle style = new GUIStyle(EditorStyles.boldLabel)
            {
                richText = true,
                normal =
                {
                    textColor = m_color
                }
            };
            GUIContent label = new GUIContent(
                $"<size={style.fontSize + headerAttribute.textHeightIncrease}><b>{headerAttribute.header}</b></size>");
            if (!headerAttribute.iconPathIsNull)
            {
                label.image = EditorGUIUtility.Load(headerAttribute.iconPath) as Texture2D;
            }

            Vector2 textSize = style.CalcSize(label);
            float labelWidth = textSize.x;
            if (!headerAttribute.iconPathIsNull)
                labelWidth += position.height - 12.5f;

            float separatorWidth = (position.width - labelWidth) / 2.0f;

            Rect prefixRect = new Rect(position.xMin - 5f, position.yMin + 3f, separatorWidth,
                                       headerAttribute.textHeightIncrease);
            Rect labelRect = new Rect(position.xMin + separatorWidth, position.yMin - 3f, labelWidth, position.height);
            Rect postRect = new Rect(position.xMin + separatorWidth + 3f + labelRect.width, position.yMin + 5f,
                                     separatorWidth - 10, headerAttribute.textHeightIncrease);
            EditorGUI.DrawRect(prefixRect, m_headerRectColor);
            EditorGUI.LabelField(labelRect, label, style);
            EditorGUI.DrawRect(postRect, m_headerRectColor);
        }

        /// <inheritdoc />
        public override float GetHeight()
        {
            HeaderAttribute headerAttribute = attribute as HeaderAttribute;
            return EditorGUIUtility.singleLineHeight * (headerAttribute?.textHeightIncrease + 0.25f ?? 1.5f);
        }

        #endregion

        public static VisualElement CreatePropertyGUI(HeaderAttribute attribute)
        {
            if (attribute == null) return null;
            Color headerRectColor = Color.gray;
            Color color = Color.white;

            if (!attribute.colorIsNull)
            {
                Debug.Assert(attribute.color != null, "headerAttribute.color != null");
                headerRectColor = color = (Color)attribute.color;
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
            container.Add(CreateBox(attribute.textHeightIncrease, headerRectColor));

            if (attribute.headerIsNull && attribute.iconPathIsNull) return container;

            if (!attribute.iconPathIsNull)
            {
                Image image = new Image
                {
                    image = EditorGUIUtility.Load(attribute.iconPath) as Texture2D,
                    scaleMode = ScaleMode.ScaleToFit
                };
                container.Add(image);
            }

            if (!attribute.headerIsNull)
            {
                Label label = new Label
                {
                    text = attribute.header,
                    name = "header-text",
                    style =
                    {
                        fontSize = 12 * attribute.textHeightIncrease,
                        color = color
                    }
                };
                container.Add(label);
            }

            container.Add(CreateBox(attribute.textHeightIncrease, headerRectColor));

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