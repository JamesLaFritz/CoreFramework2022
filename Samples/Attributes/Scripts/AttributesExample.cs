using CoreFramework.Animation;
using CoreFramework.Attributes;
using CoreFramework.Attributes.Decorators;
using CoreFramework.Attributes.Properties;
using CoreFramework.Attributes.Properties.DropDownSelection;
using CoreFramework.Attributes.Properties.Modifiers;
using UnityEngine;
using Header = CoreFramework.Attributes.Decorators.HeaderAttribute;
using Icon = CoreFramework.Attributes.Properties.Modifiers.IconAttribute;

[RequireComponent(typeof(Animator))]
public class AttributesExample : MonoBehaviour
{
    [FolderPath] public string folderPath;

    [Header("Health", "Assets/CoreFramework/Samples/Attributes/Icons/Heart.png")]
    [ReadOnly, Tooltip("The Amount of Health"), Icon("Assets/CoreFramework/Samples/Attributes/Icons/Heart.png")]
    public int health = 100;

    [Tooltip("The max amount of health")] public int maxHealth = 100;

    [Header("Info Box Attributes", "", Header.PresetColor.Blue)]
    [InfoBox("Info String To Display")]
    public float someFloat;

    [InfoBox("Some Float with no icon in box", InfoBoxType.None)]
    public float someOtherFloat;

    [InfoBox("Some Bool with a warning.", InfoBoxType.Warning)]
    public bool someBool;

    [InfoBox("Some String with an error message.", InfoBoxType.Error)]
    public string someString;

    [Header("Animation Parameters")]
    [RequiredReference]
    public Animator animator;

    public BoolAnimationParameter boolAnimationParameter;
    public FloatAnimationParameter floatAnimationParameter;
    public IntAnimationParameter intAnimationParameter;
    public TriggerAnimationParameter triggerAnimationParameter;

    [Header("Tag Attributes")]
    [Tag]
    public string tagString;

    [Header("Select Input from Legacy Input Manager", "", Header.PresetColor.Black, 1)]
    [InputAxis]
    public string inputAxisString;

    [Header("Select a Scene", "", new[] { 0.5f, 0.5f, 0.5f, 1 }, 1)]
    public bool selectScene;

    public enum SceneSelectionMode
    {
        String,
        Int
    }

    [ShowIfBool("selectScene")] public SceneSelectionMode sceneSelectionMode = SceneSelectionMode.String;

    [ShowIfBool("selectScene"), ShowIfEnumValue("sceneSelectionMode", 0), Scene]
    public string sceneName;

    [ShowIfBool("selectScene"), ShowIfEnumValue("sceneSelectionMode", 1), Scene]
    public int sceneIndex;

    [Button(ButtonAttribute.Mode.Play)]
    public void PlayModeButton()
    {
        Debug.Log($"{name}: {GetType().Name} : Play Mode Only");
    }

    [Button(ButtonAttribute.Mode.Editor)]
    public void EditModeButton()
    {
        Debug.Log($"{name}: {GetType().Name} : Edit Mode Only");
    }

    [Button]
    public void PlayAndEditModeButton()
    {
        Debug.Log($"{name}: {GetType().Name} : Play Mode and Edit Mode");
    }
}
