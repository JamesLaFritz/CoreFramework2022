using CoreFramework.Attributes;
using UnityEngine;

public class ShowIfMulti : MonoBehaviour
{
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
}
