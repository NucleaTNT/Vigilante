using Dev.NucleaTNT.Vigilante.PlayerScripts;
using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.Utilities
{
    enum EnvironmentType
    {
        GROUND,
        WATER,
        LAVA
    }
    
    public class EnvironmentZone : MonoBehaviour 
    {   
        // The player can sometimes start inside of a EnvironmentZone therefore at the beginning OnTriggerEnter2D will be called,
        // this checks for that and can then be used to prevent any unwanted manipulation
        [SerializeField] private bool _playerStartsInside;
        [SerializeField] private EnvironmentType _environmentType;
        private Player _player;
    
        private bool _isOutputEnabled;
    
        private void Awake()
        {
            _isOutputEnabled = Resources.Load<DebugVars>("Scriptable Objects/DebugVars").EnvironmentZoneOutputEnabled;
        }
    
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (_playerStartsInside) { _playerStartsInside = false; return; }
            if (other.CompareTag("Player")) _player = other.GetComponent<Player>(); else return;
            if (_isOutputEnabled) GameManager.PrintToConsole("EnvironmentZone", "OnTriggerEnter2D", $"Player entered {_environmentType} zone!");
    
            switch (_environmentType)
            {
                case EnvironmentType.GROUND: 
                {
                    _player.IsSwimming = false;
                    break;
                } 
                
                case EnvironmentType.WATER:
                {
                    _player.IsSwimming = true;
                    break;
                } 
    
                case EnvironmentType.LAVA: break;   // TODO
            }
        }
        
        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.CompareTag("Player")) _player = other.GetComponent<Player>(); else return;
            if (_isOutputEnabled) GameManager.PrintToConsole("EnvironmentZone", "OnTriggerExit2D", $"Player left {_environmentType} zone!");
    
            switch (_environmentType)
            {
                case EnvironmentType.GROUND: 
                {
                    _player.IsSwimming = true;
                    break;
                } 
                
                case EnvironmentType.WATER: 
                {
                    _player.IsSwimming = false;
                    break;
                }
    
                case EnvironmentType.LAVA: break;   // TODO
            }
        }
    }
}
