using CoreFramework.Attributes;
using UnityEngine;

namespace CoreFramework.Settings
{
    [CreateAssetMenu(fileName = "CoreFrameworkSettings", menuName = CoreFrameworkMenu.MainMenu + "Settings")]
    public class CoreFrameworkSettingsSO : ScriptableObject
    {
        [Scene]public string startScene = "SampleScene";
        [Scene]public string bootSceneScene = "Bootstrapper";
        
        public bool showDebug = true;

        public int infoSize = 14;
        public int warningSize = 15;
        public int errorSize = 16;
    }
}