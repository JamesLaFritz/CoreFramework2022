using UnityEngine;
using HeaderAttribute = CoreFramework.Attributes.HeaderAttribute;

public class HeaderExample : MonoBehaviour
{
    [Header("Health", "", new[] { 1f, 1f, 1f })]
    public float health = 100;

    [Header("Health", "", new[] { 0.5f, 0.5f, 0.5f }, 2f)]
    public float health1 = 100;

    [Header("Health", "Assets/CoreFramework/Samples/Attributes/Icons/Heart.png", new[] { 1f, 1f, 1f })]
    public float health2 = 100;

    [Header("", "", new[] { 0f, 0f, 0f, 1f })]
    public float health3 = 100;

    [Header("", "Assets/CoreFramework/Samples/Attributes/Icons/Heart.png", new[] { 0.5f, 0.5f, 0.5f }, 2f)]
    public float health4 = 100;

    [Header("Health", "Assets/CoreFramework/Samples/Attributes/Icons/Heart.png")]
    public float health5 = 100;

    [Header("Health", "Assets/CoreFramework/Samples/Attributes/Icons/Heart.png", 2f)]
    public float health6 = 100;

    [Header("Assets/CoreFramework/Samples/Attributes/Icons/Heart.png", false)]
    public float health7 = 100;

    [Header("Health")] public float health8 = 100;

    [Header("Health", "", HeaderAttribute.PresetColor.Green)]
    public float health9 = 100;

    [Header("", "", HeaderAttribute.PresetColor.Magenta, 0.5f)]
    public float health10 = 100;

    [Header("Health", "Assets/CoreFramework/Samples/Attributes/Icons/Heart.png", HeaderAttribute.PresetColor.Cyan)]
    public float health11 = 100;

    [Header("", "Assets/CoreFramework/Samples/Attributes/Icons/Heart.png", HeaderAttribute.PresetColor.Blue)]
    public float health12 = 100;

    [Header("", "", HeaderAttribute.PresetColor.Black)]
    [Header("Health Range")]
    [Range(0, 500)]
    public float healthRange = 100;

    [Range(0, 100)] [Header("Health Range")]
    public float healthRange1 = 100;
}
