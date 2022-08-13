using CoreFramework.Attributes.Decorators;
using UnityEngine;

public class InfoBoxExample : MonoBehaviour
{
    [InfoBox("Info String To Display")] public float someFloat;

    [InfoBox("Some Float with no icon in box", InfoBoxType.None)]
    public float someOtherFloat;

    [InfoBox("Some Bool with a warning.", InfoBoxType.Warning)]
    public bool someBool;

    [InfoBox("Some String with an error message.", InfoBoxType.Error)]
    public string someString;
}
