using UnityEngine;

namespace Dev.NucleaTNT.Utilities 
{
    [CreateAssetMenu(fileName = "VersionInfo", menuName = "Scriptable Objects/VersionInfo")]
    public class VersionInfo : ScriptableObject
    {
        public string VersionNumber;
        [Multiline] public string ChangeLog;
    }
}
