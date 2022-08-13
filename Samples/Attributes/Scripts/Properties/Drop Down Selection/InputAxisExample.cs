using CoreFramework.Attributes.Properties.DropDownSelection;
using CoreFramework.Attributes.Properties.Modifiers;
using UnityEngine;

public class InputAxisExample : MonoBehaviour
{
    [InputAxis] public string inputToUse;

    [ReadOnly] public float inputAxis;
    [ReadOnly] public bool inputPressed;

    private void Update()
    {
        if (string.IsNullOrWhiteSpace(inputToUse)) return;
        inputAxis = Input.GetAxis(inputToUse);
        inputPressed = Input.GetButton(inputToUse);
    }
}
