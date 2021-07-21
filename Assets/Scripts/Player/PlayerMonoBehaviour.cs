using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMonoBehaviour : MonoBehaviour
{
    public Player ThisPlayer {get; private set;}

    private void Awake()
    {
        ThisPlayer = gameObject.GetComponentInParent<Player>();     // Try looking in the parent object if attached object isn't main player object
    }
}