using CoreFramework.Attributes;
using UnityEngine;

public class ReadOnlyExample : MonoBehaviour
{
    [ReadOnly] public int inspectorReadOnlyInt = 400;
}
