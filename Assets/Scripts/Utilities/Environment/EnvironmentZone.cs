using Dev.NucleaTNT.Vigilante.Interfaces;
using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.Utilities
{
    public enum EnvironmentType
    {
        GROUND,
        WATER,
        LAVA
    }
    
    public class EnvironmentZone : MonoBehaviour 
    {   
        [SerializeField] private EnvironmentType _environmentType;
        private bool _isOutputEnabled;
    
        private void Awake()
        {
            _isOutputEnabled = GameManager.DebugVars.EnvironmentZoneOutputEnabled;
        }
    
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent<IEnvironment>(out IEnvironment environmentComp)) 
            {
                if (_isOutputEnabled) GameManager.PrintToConsole("EnvironmentZone", "OnTriggerEnter2D", $"{other.name} entered {_environmentType}.");
                environmentComp.EnvironmentUpdate(_environmentType, true);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.TryGetComponent<IEnvironment>(out IEnvironment environmentComp)) 
            {
                if (_isOutputEnabled) GameManager.PrintToConsole("EnvironmentZone", "OnTriggerExit2D", $"{other.name} exited {_environmentType}.");
                environmentComp.EnvironmentUpdate(_environmentType, false);
            }
        }
    }
}
