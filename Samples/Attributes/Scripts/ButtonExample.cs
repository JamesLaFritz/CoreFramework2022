using CoreFramework.Attributes;
using UnityEngine;

public class ButtonExample : MonoBehaviour
{
    [Button(ButtonAttribute.Mode.Play)]
    public void PlayModeButton()
    {
        Debug.Log($"{name}: Play Mode Only");
    }

    [Button(ButtonAttribute.Mode.Editor)]
    public void EditModeButton()
    {
        Debug.Log($"{name} : Edit Mode Only");
    }

    [Button]
    public void PlayAndEditModeButton()
    {
        Debug.Log($"{name}: Play Mode and Edit Mode");
    }
}
