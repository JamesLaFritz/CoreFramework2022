// UIElementsCustomEditor.cs
// 07-22-2022
// James LaFritz

using System.Collections.Generic;
using CoreFramework.Attributes.Decorators;
using CoreFramework.Attributes.Properties;
using CoreFramework.Attributes.Properties.Modifiers;
using CoreFramework.Runtime;
using CoreFrameworkEditor.Attributes.Decorators;
using CoreFrameworkEditor.Inspector.InspectorButton;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using HeaderAttribute = CoreFramework.Attributes.Decorators.HeaderAttribute;
using Toggle = UnityEngine.UIElements.Toggle;

namespace CoreFrameworkEditor.Inspector
{
    /// <summary>
    /// A custom inspector or editor for UIElementsMonoBehaviour
    /// <a href="https://docs.unity3d.com/ScriptReference/Editor.html">UnityEditor.Editor</a>
    /// </summary>
    [CustomEditor(typeof(UIElementsMonoBehaviour), true)]
    public class UIElementsCustomEditor : Editor
    {
        struct ShowIf
        {
            public SerializedProperty controlProperty;
            public VisualElement element;
        }

        /// <summary>
        /// The button attribute helper
        /// </summary>
        private readonly ButtonAttributeHelper _helper = new ButtonAttributeHelper();

        private readonly Dictionary<string, ShowIf> _showIfBool = new Dictionary<string, ShowIf>();
        private readonly Dictionary<string, ShowIf> _showIfEnum = new Dictionary<string, ShowIf>();

        private void OnEnable()
        {
            _helper.Init(target);
        }

        #region Overrides of Editor

        /// <inheritdoc />
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            serializedObject.UpdateIfRequiredOrScript();
            CreateProperties(root);

            SerializedProperty property = serializedObject.GetIterator();
            bool expanded = true;
            // while (property.NextVisible(expanded))
            // {
            //     string propertyName = property.name;
            //
            //     if (!string.IsNullOrWhiteSpace(propertyName))
            //     {
            //         if (_showIfBool.ContainsKey(propertyName))
            //         {
            //             ShowIfBoolAttribute boolAttribute = property.GetAttribute<ShowIfBoolAttribute>();
            //             ShowIf showIf = _showIfBool[propertyName];
            //             VisualElement element = showIf.element;
            //             SerializedProperty controlProperty = showIf.controlProperty;
            //             VisualElement controlElement = root.Q<VisualElement>(controlProperty.name);
            //             Toggle toggle = controlElement?.Q<Toggle>();
            //             if (toggle != null && element != null)
            //             {
            //                 toggle.value = controlProperty.boolValue;
            //                 element.style.display =
            //                     PropertyDrawerHelper.ShouldShow(toggle.value, boolAttribute.show)
            //                         ? DisplayStyle.Flex
            //                         : DisplayStyle.None;
            //                 toggle.RegisterValueChangedCallback(evt =>
            //                 {
            //                     controlProperty.boolValue = evt.newValue;
            //                     serializedObject.ApplyModifiedProperties();
            //                     element.style.display =
            //                         PropertyDrawerHelper.ShouldShow(evt.newValue, boolAttribute.show)
            //                             ? DisplayStyle.Flex
            //                             : DisplayStyle.None;
            //                 });
            //             }
            //         }
            //
            //         if (_showIfEnum.ContainsKey(propertyName))
            //         {
            //             ShowIfEnumValueAttribute enumAttribute = property.GetAttribute<ShowIfEnumValueAttribute>();
            //             ShowIf showIf = _showIfEnum[propertyName];
            //             VisualElement element = showIf.element;
            //             SerializedProperty controlProperty = showIf.controlProperty;
            //             VisualElement controlElement = root.Q<VisualElement>(controlProperty.name);
            //             DropdownField dropdown = controlElement?.Q<DropdownField>();
            //             if (dropdown != null && element != null)
            //             {
            //                 element.style.display =
            //                     PropertyDrawerHelper.ShouldShow(
            //                         dropdown.index == enumAttribute.enumIndex, enumAttribute.show)
            //                         ? DisplayStyle.Flex
            //                         : DisplayStyle.None;
            //                 // controlElement.RegisterValueChangedCallback(evt =>
            //                 // {
            //                 //     element.style.display =
            //                 //         PropertyDrawerHelper.ShouldShow(evt.newValue,
            //                 //             controlProperty.GetAttribute<ShowIfEnumValueAttribute>().show)
            //                 //             ? DisplayStyle.Flex
            //                 //             : DisplayStyle.None;
            //                 // });
            //             }
            //             element.style.display = showIf.controlProperty.enumValueIndex == 0
            //                 ? DisplayStyle.Flex
            //                 : DisplayStyle.None;
            //         }
            //     }
            //
            //     expanded = false;
            // }

            return root;
        }

        #endregion

        private void CreateProperties(VisualElement root)
        {
            _showIfBool.Clear();
            _showIfEnum.Clear();
            SerializedProperty property = serializedObject.GetIterator();
            bool expanded = true;
            while (property.NextVisible(expanded))
            {
                bool disabled = "m_Script" == property.propertyPath;

                VisualElement propertyFieldContainer = new VisualElement
                {
                    name = property.name + "-property-field-container"
                };
                root.Add(propertyFieldContainer);

                VisualElement attributeDecoratorContainer = new VisualElement
                {
                    name = "attribute-decorator-container"
                };
                propertyFieldContainer.Add(attributeDecoratorContainer);

                HeaderAttribute headerAttribute = property.GetAttribute<HeaderAttribute>();
                if (headerAttribute != null)
                {
                    attributeDecoratorContainer.Add(HeaderAttributeDecoratorDrawer.CreatePropertyGUI(headerAttribute));
                }

                InfoBoxAttribute infoBoxAttribute = property.GetAttribute<InfoBoxAttribute>();
                if (infoBoxAttribute != null)
                {
                    attributeDecoratorContainer.Add(InfoBoxDecoratorDrawer.CreatePropertyGUI(infoBoxAttribute));
                }

                VisualElement propertyField = new VisualElement
                {
                    name = "property-field",
                    style =
                    {
                        flexDirection = FlexDirection.Row,
                        flexGrow = 1,
                        flexShrink = 1
                    }
                };
                propertyField.SetEnabled(!disabled);
                propertyFieldContainer.Add(propertyField);

                IconAttribute iconAttribute = property.GetAttribute<IconAttribute>();
                if (iconAttribute != null)
                    propertyField.Add(PropertyDrawerHelper.CreateIconGUI(iconAttribute.Path));

                propertyField.Add(new PropertyField(property, property.displayName)
                                      { name = property.name, style = { minWidth = 300 } });

                ShowIfBoolAttribute showIfBoolAttribute = property.GetAttribute<ShowIfBoolAttribute>();
                if (showIfBoolAttribute != null)
                {
                    _showIfBool.Add(property.name!, new ShowIf
                    {
                        controlProperty = property,
                        element = propertyFieldContainer
                    });
                }

                ShowIfEnumValueAttribute showIfEnumValueAttribute = property.GetAttribute<ShowIfEnumValueAttribute>();
                if (showIfEnumValueAttribute != null)
                {
                    _showIfEnum.Add(property.name!, new ShowIf
                    {
                        controlProperty = property,
                        element = propertyFieldContainer
                    });
                }

                expanded = false;
            }

            serializedObject.ApplyModifiedProperties();

            root.Add(_helper.CreateButtons());
        }
    }
}