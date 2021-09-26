using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.PlayerScripts
{
    [RequireComponent(typeof(Player))]
    public class PlayerMonoBehaviour : MonoBehaviour
    {
        public Player ThisPlayer {get; private set;}
    
        protected virtual void Awake() =>
            ThisPlayer = gameObject.GetComponentInParent<Player>();     // Try looking in the parent object if attached object isn't main player object
        
    }
}