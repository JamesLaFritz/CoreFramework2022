using CoreFramework.Attributes.Properties.Modifiers;
using UnityEngine;

public class ReadOnlyExample : MonoBehaviour
{
    [ReadOnly] public int inspectorReadOnlyInt = 400;
}
