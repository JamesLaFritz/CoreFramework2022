using CoreFramework.Attributes;
using UnityEngine;

public class ButtonExample : MonoBehaviour
{
    [Button(ButtonAttribute.ButtonMode.Play)]
    public void PlayModeButton()
    {
        Debug.Log($"{name}: Play Mode Only");
    }

    [Button(ButtonAttribute.ButtonMode.Editor)]
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
