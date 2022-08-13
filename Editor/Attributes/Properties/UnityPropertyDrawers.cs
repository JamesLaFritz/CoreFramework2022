#region Description

// ----------------------------------------------------------------------------
// Came from
// https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/ScriptAttributeGUI/Implementations/PropertyDrawers.cs
//
// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License
//
// Reproduced the Unity Attributes in order to add my Custom property drawers.
// Added PropertyDrawerHelper.LoadAttributeTooltip(this, label); And PropertyDrawerHelper.LoadAttributeIcon(this, label);
// This is so the custom attributes i.e. Icon get displayed correctly with these attributes
// ----------------------------------------------------------------------------

#endregion

using System;
using CoreFrameworkEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor
{
    // Built-in PropertyDrawers. See matching attributes in PropertyAttribute.cs

    [CustomPropertyDrawer(typeof(RangeAttribute))]
    internal sealed class RangeDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage = L10n.Tr("Use Range with float or int.");

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RangeAttribute range = (RangeAttribute)attribute;
            PropertyDrawerHelper.LoadAttributes(this, label);

            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:
                    EditorGUI.Slider(position, property, range.min, range.max, label);
                    break;
                case SerializedPropertyType.Integer:
                    EditorGUI.IntSlider(position, property, (int)range.min, (int)range.max, label);
                    break;
                default:
                    EditorGUI.LabelField(position, label.text, SInvalidTypeMessage);
                    break;
            }
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            RangeAttribute range = (RangeAttribute)attribute;

            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:
                {
                    Slider slider = new Slider(property.displayName, range.min, range.max)
                    {
                        name = "unity-slider",
                        bindingPath = property.propertyPath,
                        showInputField = true
                    };
                    return slider;
                }
                case SerializedPropertyType.Integer:
                {
                    SliderInt intSlider = new SliderInt(property.displayName, (int)range.min, (int)range.max)
                    {
                        name = "unity-slider",
                        bindingPath = property.propertyPath,
                        showInputField = true
                    };
                    return intSlider;
                }
                default:
                    return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };
            }
        }
    }

    [CustomPropertyDrawer(typeof(MinAttribute))]
    internal sealed class MinDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage = L10n.Tr("Use Min with float, int or Vector.");

        private MinAttribute MinAttribute => attribute as MinAttribute;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PropertyDrawerHelper.LoadAttributes(this, label);

            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();
            EditorGUI.PropertyField(position, property, label);
            if (!changeCheck.changed) return;

            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:
                    property.floatValue = Mathf.Max(MinAttribute.min, property.floatValue);
                    break;
                case SerializedPropertyType.Integer:
                    property.intValue = Mathf.Max((int)MinAttribute.min, property.intValue);
                    break;
                case SerializedPropertyType.Vector2:
                {
                    Vector2 value = property.vector2Value;
                    property.vector2Value = new Vector2(Mathf.Max(MinAttribute.min, value.x), Mathf.Max(MinAttribute.min, value.y));
                    break;
                }
                case SerializedPropertyType.Vector2Int:
                {
                    Vector2Int value = property.vector2IntValue;
                    property.vector2IntValue = new Vector2Int(Mathf.Max((int)MinAttribute.min, value.x), Mathf.Max((int)MinAttribute.min, value.y));
                    break;
                }
                case SerializedPropertyType.Vector3:
                {
                    Vector3 value = property.vector3Value;
                    property.vector3Value = new Vector3(Mathf.Max(MinAttribute.min, value.x), Mathf.Max(MinAttribute.min, value.y), Mathf.Max(MinAttribute.min, value.z));
                    break;
                }
                case SerializedPropertyType.Vector3Int:
                {
                    Vector3Int value = property.vector3IntValue;
                    property.vector3IntValue = new Vector3Int(Mathf.Max((int)MinAttribute.min, value.x), Mathf.Max((int)MinAttribute.min, value.y), Mathf.Max((int)MinAttribute.min, value.z));
                    break;
                }
                case SerializedPropertyType.Vector4:
                {
                    Vector4 value = property.vector4Value;
                    property.vector4Value = new Vector4(Mathf.Max(MinAttribute.min, value.x), Mathf.Max(MinAttribute.min, value.y), Mathf.Max(MinAttribute.min, value.z), Mathf.Max(MinAttribute.min, value.w));
                    break;
                }
                default:
                    EditorGUI.LabelField(position, label.text, SInvalidTypeMessage);
                    break;
            }
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            BindableElement newField = null;

            switch (property.propertyType)
            {
                case SerializedPropertyType.Float when property.type == "float":
                    newField = new FloatField(property.displayName);
                    newField.name = "unity-float-field";
                    ((BaseField<float>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.floatValue =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Float when property.type == "double":
                    newField = new DoubleField(property.displayName);
                    newField.name = "unity-double-field";
                    ((BaseField<double>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.doubleValue =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Integer when property.type == "int":
                    newField = new IntegerField(property.displayName);
                    newField.name = "unity-int-field";
                    ((BaseField<int>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.intValue =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Integer when property.type == "long":
                    newField = new LongField(property.displayName);
                    newField.name = "unity-long-field";
                    ((BaseField<long>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.longValue =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Vector2:
                    newField = new Vector2Field(property.displayName);
                    newField.name = "unity-vector2-field";
                    ((BaseField<Vector2>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.vector2Value =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Vector2Int:
                    newField = new Vector2IntField(property.displayName);
                    newField.name = "unity-vector2int-field";
                    ((BaseField<Vector2Int>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.vector2IntValue =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Vector3:
                    newField = new Vector3Field(property.displayName);
                    newField.name = "unity-vector3-field";
                    ((BaseField<Vector3>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.vector3Value =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Vector3Int:
                    newField = new Vector3IntField(property.displayName);
                    newField.name = "unity-vector3int-field";
                    ((BaseField<Vector3Int>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.vector3IntValue =
                            OnValidateValue(evt.newValue);
                    });
                    break;
                case SerializedPropertyType.Vector4:
                    newField = new Vector4Field(property.displayName);
                    newField.name = "unity-vector4-field";
                    ((BaseField<Vector4>)newField).RegisterValueChangedCallback(evt =>
                    {
                        property.vector4Value =
                            OnValidateValue(evt.newValue);
                    });
                    break;
            }

            if (newField == null) return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };
            newField.bindingPath = property.propertyPath;
            return newField;
        }

        private float OnValidateValue(float value)
        {
            return Mathf.Max(MinAttribute.min, value);
        }

        private double OnValidateValue(double value)
        {
            return Math.Max(MinAttribute.min, value);
        }

        private int OnValidateValue(int value)
        {
            return Mathf.Max((int)MinAttribute.min, value);
        }

        private long OnValidateValue(long value)
        {
            return Math.Max((long)MinAttribute.min, value);
        }

        private Vector2 OnValidateValue(Vector2 value)
        {
            return new Vector2(Mathf.Max(MinAttribute.min, value.x), Mathf.Max(MinAttribute.min, value.y));
        }

        private Vector2Int OnValidateValue(Vector2Int value)
        {
            return new Vector2Int(Mathf.Max((int)MinAttribute.min, value.x), Mathf.Max((int)MinAttribute.min, value.y));
        }

        private Vector3 OnValidateValue(Vector3 value)
        {
            return new Vector3(Mathf.Max(MinAttribute.min, value.x), Mathf.Max(MinAttribute.min, value.y),
                               Mathf.Max(MinAttribute.min, value.z));
        }

        private Vector3Int OnValidateValue(Vector3Int value)
        {
            return new Vector3Int(Mathf.Max((int)MinAttribute.min, value.x), Mathf.Max((int)MinAttribute.min, value.y),
                                  Mathf.Max((int)MinAttribute.min, value.z));
        }

        private Vector4 OnValidateValue(Vector4 value)
        {
            return new Vector4(Mathf.Max(MinAttribute.min, value.x), Mathf.Max(MinAttribute.min, value.y),
                               Mathf.Max(MinAttribute.min, value.z), Mathf.Max(MinAttribute.min, value.w));
        }
    }

    [CustomPropertyDrawer(typeof(MultilineAttribute))]
    internal sealed class MultilineDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage = L10n.Tr("Use Multiline with string.");
        private const int KLineHeight = 13;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, label.text, SInvalidTypeMessage);
                return;
            }

            PropertyDrawerHelper.LoadAttributes(this, label);

            using EditorGUI.PropertyScope propertyScope = new EditorGUI.PropertyScope(position, label, property);
            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();
            int oldIndent = EditorGUI.indentLevel;
            EditorGUI.indentLevel =
                0; // The MultiFieldPrefixLabel already applied indent, so avoid indent of TextArea itself.
            string newValue = EditorGUI.TextArea(position, property.stringValue);
            EditorGUI.indentLevel = oldIndent;
            if (changeCheck.changed)
                property.stringValue = newValue;
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.String)
                return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };
            int lines = ((MultilineAttribute)attribute).lines;
            TextField field = new TextField(property.displayName)
            {
                name = "unity-text-field",
                multiline = true,
                bindingPath = property.propertyPath,
                style =
                {
                    height = EditorGUIUtility.singleLineHeight + (lines - 1) * KLineHeight
                }
            };
            return field;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return (EditorGUIUtility.wideMode ? 0 : (int)EditorGUIUtility.singleLineHeight) // header
                   + EditorGUIUtility.singleLineHeight // first line
                   + (((MultilineAttribute)attribute).lines - 1) * KLineHeight; // remaining lines
        }
    }

    [CustomPropertyDrawer(typeof(TextAreaAttribute))]
    internal sealed class TextAreaDrawer : PropertyDrawer
    {
        private const int KLineHeight = 13;
        private static readonly string SInvalidTypeMessage = L10n.Tr("Use TextAreaDrawer with string.");
        private Vector2 m_scrollPosition;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, label.text, SInvalidTypeMessage);
                return;
            }

            PropertyDrawerHelper.LoadAttributes(this, label);

            using EditorGUI.PropertyScope propertyScope = new EditorGUI.PropertyScope(position, label, property);
            label = propertyScope.content;
            Rect labelPosition = EditorGUI.IndentedRect(position);
            labelPosition.height = EditorGUIUtility.singleLineHeight;
            position.yMin += labelPosition.height;
            EditorGUI.HandlePrefixLabel(position, labelPosition, label);

            using GUI.ScrollViewScope scrollViewScope = new GUI.ScrollViewScope(position, m_scrollPosition,
                new Rect(position.x, position.y, EditorGUIUtility.currentViewWidth, EditorStyles.textArea.CalcHeight(
                             new GUIContent(property.stringValue), EditorGUIUtility.currentViewWidth)));

            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();
            string newValue = EditorGUI.TextArea(position, property.stringValue);
            if (changeCheck.changed)
                property.stringValue = newValue;

            m_scrollPosition = scrollViewScope.scrollPosition;
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.String)
                return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };

            TextAreaAttribute textAreaAttribute = attribute as TextAreaAttribute;

            float minHeight = EditorGUIUtility.singleLineHeight + (textAreaAttribute.minLines - 1) * KLineHeight;
            float maxHeight = minHeight;

            VisualElement element = new VisualElement
            {
                name = "unity-text-container"
            };

            Label label = new Label(property.displayName)
            {
                name = "unity-label"
            };

            ScrollView scrollView = new ScrollView
            {
                style =
                {
                    minHeight = minHeight,
                    maxHeight = maxHeight
                }
            };

            TextField textField = new TextField
            {
                name = "unity-text-field",
                multiline = true,
                style =
                {
                    minHeight = minHeight
                },
                bindingPath = property.propertyPath
            };

            scrollView.Add(textField);

            element.Add(label);
            element.Add(scrollView);

            return element;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            TextAreaAttribute textAreaAttribute = attribute as TextAreaAttribute;
            GUIContent text = new GUIContent(property.stringValue);

            float fullTextHeight = EditorStyles.textArea.CalcHeight(text, EditorGUIUtility.currentViewWidth);
            int lines = Mathf.CeilToInt(fullTextHeight / KLineHeight);

            lines = Mathf.Clamp(lines, textAreaAttribute.minLines, textAreaAttribute.maxLines);

            return EditorGUIUtility.singleLineHeight // header
                   + EditorGUIUtility.singleLineHeight // first line
                   + (lines - 1) * KLineHeight; // remaining lines
        }
    }

    [CustomPropertyDrawer(typeof(ColorUsageAttribute))]
    internal sealed class ColorUsageDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage = L10n.Tr("Use ColorUsageDrawer with color.");

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ColorUsageAttribute colorUsage = (ColorUsageAttribute)attribute;
            if (property.propertyType != SerializedPropertyType.Color)
            {
                EditorGUI.ColorField(position, label, property.colorValue, true, colorUsage.showAlpha, colorUsage.hdr);
                return;
            }

            PropertyDrawerHelper.LoadAttributes(this, label);
            using EditorGUI.PropertyScope propertyScope = new EditorGUI.PropertyScope(position, label, property);
            label = propertyScope.content;
            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();
            Color newColor = EditorGUI.ColorField(position, label, property.colorValue, true, colorUsage.showAlpha,
                                                  colorUsage.hdr);

            if (changeCheck.changed)
                property.colorValue = newColor;
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.Color)
                return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };
            ColorUsageAttribute colorUsage = (ColorUsageAttribute)attribute;
            ColorField field = new ColorField(property.displayName)
            {
                name = "unity-color-field",
                showAlpha = colorUsage.showAlpha,
                hdr = colorUsage.hdr,
                bindingPath = property.propertyPath
            };
            return field;
            ;
        }
    }

    [CustomPropertyDrawer(typeof(DelayedAttribute))]
    internal sealed class DelayedDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage = L10n.Tr("Use Delayed with float, int, or string.");

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PropertyDrawerHelper.LoadAttributes(this, label);

            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:
                    EditorGUI.DelayedFloatField(position, property, label);
                    break;
                case SerializedPropertyType.Integer:
                    EditorGUI.DelayedIntField(position, property, label);
                    break;
                case SerializedPropertyType.String:
                    EditorGUI.DelayedTextField(position, property, label);
                    break;
                default:
                    EditorGUI.LabelField(position, label.text, SInvalidTypeMessage);
                    break;
            }
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            BindableElement newField = null;
            switch (property.propertyType)
            {
                case SerializedPropertyType.Float when property.type == "float":
                    newField = new FloatField(property.displayName);
                    newField.name = "unity-delayed-float-field";
                    ((TextInputBaseField<float>)newField).isDelayed = true;
                    break;
                case SerializedPropertyType.Float when property.type == "double":
                {
                    newField = new DoubleField(property.displayName);
                    newField.name = "unity-delayed-double-field";
                    ((TextInputBaseField<double>)newField).isDelayed = true;
                    break;
                }
                case SerializedPropertyType.Integer when property.type == "int":
                    newField = new IntegerField(property.displayName);
                    newField.name = "unity-delayed-int-field";
                    ((TextInputBaseField<int>)newField).isDelayed = true;
                    break;
                case SerializedPropertyType.Integer when property.type == "long":
                    newField = new LongField(property.displayName);
                    newField.name = "unity-delayed-long-field";
                    ((TextInputBaseField<long>)newField).isDelayed = true;
                    break;
                case SerializedPropertyType.String:
                    newField = new TextField(property.displayName);
                    newField.name = "unity-delayed-text-field";
                    ((TextInputBaseField<string>)newField).isDelayed = true;
                    break;
            }

            if (newField == null) return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };
            newField.bindingPath = property.propertyPath;
            return newField;
        }
    }
}