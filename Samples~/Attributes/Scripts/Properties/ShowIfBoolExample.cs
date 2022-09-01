using CoreFramework.Attributes;
using UnityEngine;

public class ShowIfBoolExample : MonoBehaviour
{
    public bool showHideValue;

    // Shows this value if showHideValue = true;
    [ShowIfBool("showHideValue")] public int showIfTrueInt;

    // Shows this value if showHideValue = false;
    [ShowIfBool("showHideValue", false)] public int showIfFalseInt;

    // Shows this value as a Range if showHideValue = true;
    [ShowIfBool("showHideValue"), Range(5, 20)]
    public int showIfTrueRangeInt1;

    // Shows this value as a Range if showHideValue = true;
    // Since Range is first this value is always shown
    [Range(5, 20), ShowIfBool("showHideValue")]
    public int showIfTrueRangeInt2;
}
