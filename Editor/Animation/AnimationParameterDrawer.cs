// AnimationParameterDrawer.cs
// 07-21-2022
// James LaFritz
// From Bit Cake Studio's BitStrap
// https://assetstore.unity.com/publishers/4147

using System.Linq;
using System.Reflection;
using CoreFramework.Animation;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Animation
{
    /// <summary>
    /// From Bit Cake Studio's BitStrap
    /// https://assetstore.unity.com/publishers/4147
    /// A property drawer for AnimationParameter
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(AnimationParameter), true)]
    public class AnimationParameterDrawer : PropertyDrawer
    {
        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PropertyDrawerHelper.LoadAttributes(this, label);

            Animator animator = GetAnimator(property);

            if (animator == null || !animator.isActiveAndEnabled || animator.runtimeAnimatorController == null)
            {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            SerializedProperty nameProperty = property.FindPropertyRelative("name");

            string[] choices = GetAnimatorParameters(property, animator);

            if (choices == null || choices.Length == 0)
            {
                EditorGUI.PropertyField(position, nameProperty, label);
                return;
            }

            int currentIndex = GetSelectedIndex(nameProperty.stringValue, choices);
            GUIContent[] popupOptions = choices.Select(x => new GUIContent(x)).ToArray();

            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();
            currentIndex = EditorGUI.Popup(position, label, currentIndex, popupOptions);
            if (!changeCheck.changed) return;
            nameProperty.stringValue = choices[currentIndex];
            property.serializedObject?.ApplyModifiedProperties();
        }

        /// <inheritdoc />
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            Animator animator = GetAnimator(property);

            PropertyField propertyField = new PropertyField(property, property.displayName)
            {
                name = "unity-property-field"
            };

            if (animator == null || !animator.isActiveAndEnabled || animator.runtimeAnimatorController == null)
                return propertyField;

            string[] choices = GetAnimatorParameters(property, animator);

            if (choices == null || choices.Length == 0)

                return propertyField;

            SerializedProperty nameProperty = property.FindPropertyRelative("name");
            PopupField<string> popupField =
                new PopupField<string>(property.displayName, choices!.ToList(), GetSelectedIndex(nameProperty.stringValue, choices))
                {
                    name = "unity-popup-field"
                };
            popupField.BindProperty(nameProperty);

            return popupField;
        }

        #endregion

        private AnimatorControllerParameter[] FilterParameters(SerializedProperty property, Animator animator)
        {
            string t = property.type;
            return t switch
            {
                nameof(BoolAnimationParameter) => animator.parameters!
                    .Where(x => x.type == AnimatorControllerParameterType.Bool)
                    .ToArray(),
                nameof(IntAnimationParameter) => animator.parameters!
                    .Where(x => x.type == AnimatorControllerParameterType.Int)
                    .ToArray(),
                nameof(FloatAnimationParameter) => animator.parameters!
                    .Where(x => x.type == AnimatorControllerParameterType.Float)
                    .ToArray(),
                nameof(TriggerAnimationParameter) => animator.parameters!
                    .Where(x => x.type == AnimatorControllerParameterType.Trigger)
                    .ToArray(),
                _ => animator!.parameters
            };
        }

        private Animator GetAnimator(SerializedProperty property)
        {
            MonoBehaviour behaviour = property.serializedObject.targetObject as MonoBehaviour;

            if (behaviour == null) return null;
            AnimatorFieldAttribute animatorField = fieldInfo!.GetCustomAttribute<AnimatorFieldAttribute>(false);
            if (animatorField == null) return behaviour.GetComponentInChildren<Animator>();
            SerializedProperty animatorProperty =
                property.serializedObject.FindProperty(animatorField.animatorFieldName);
            if (animatorProperty != null)
                return animatorProperty.objectReferenceValue as Animator;
            return null;
        }

        private string[] GetAnimatorParameters(SerializedProperty property, Animator animator)
        {
            if (animator == null || !animator.isActiveAndEnabled || animator.runtimeAnimatorController == null)
                return null;

            AnimatorControllerParameter[] parameters = FilterParameters(property, animator);
            if (parameters == null) Debug.Log("parameters == null");
            else if (parameters.Length == 0) Debug.Log("parameters.Length == 0");
            if (parameters == null || parameters.Length == 0) return null;

            return parameters!.Select(x => x.name).ToArray();
        }

        private static int GetSelectedIndex(string propertyString, string[] animationParameterNames)
        {
            int index = 0;
            // check if there is an entry that matches the entry and get the index
            // we skip index 0 as that is a special custom case
            for (int i = 1; i < animationParameterNames.Length; i++)
            {
                if (animationParameterNames[i] == null) continue;
                if (!animationParameterNames[i].Equals(propertyString, System.StringComparison.Ordinal)) continue;
                index = i;
                break;
            }

            return index;
        }
    }
}