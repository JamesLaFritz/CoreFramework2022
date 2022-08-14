using CoreFramework.Attributes.Properties;
using UnityEngine;

public class ShowIfEnumExample : MonoBehaviour
{
    public enum SomeEnum
    {
        One,
        Two,
        Three
    }

    public SomeEnum someEnum = SomeEnum.One;

    [ShowIfEnumValue("someEnum", (int)SomeEnum.One)]
    public int showIfSomeEnumOne;

    [ShowIfEnumValue("someEnum", (int)SomeEnum.One, false)]
    public int showIfSomeEnumNotOne;

    [ShowIfEnumValue("someEnum", (int)SomeEnum.Two)]
    public int showIfSomeEnumTwo;

    [ShowIfEnumValue("someEnum", (int)SomeEnum.Two, false)]
    public int showIfSomeEnumNotTwo;

    [ShowIfEnumValue("someEnum", (int)SomeEnum.Three)]
    public int showIfSomeEnumThree;

    [ShowIfEnumValue("someEnum", (int)SomeEnum.Three, false)]
    public int showIfSomeEnumNotThree;
}
