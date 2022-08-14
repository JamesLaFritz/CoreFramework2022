using CoreFramework.Attributes.Properties;
using UnityEngine;

public class FolderPathExample : MonoBehaviour
{
    [FolderPath(false)] public string absolutePath;
    [FolderPath(true)] public string relativePath;
}
