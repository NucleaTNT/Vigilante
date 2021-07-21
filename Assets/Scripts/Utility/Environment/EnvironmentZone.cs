using UnityEngine;

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
    [SerializeField] private bool playerStartsInside;
    [SerializeField] private EnvironmentType environmentType;
    private Player player;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (playerStartsInside) { playerStartsInside = false; return; }
        if (other.CompareTag("Player")) player = other.GetComponent<Player>(); else return;

        switch (environmentType)
        {
            case EnvironmentType.GROUND: 
            {
                player.IsSwimming = false;
                break;
            } 
            
            case EnvironmentType.WATER: 
            {
                player.IsSwimming = true;
                break;
            } 

            case EnvironmentType.LAVA: break;   // TODO
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) player = other.GetComponent<Player>(); else return;

        switch (environmentType)
        {
            case EnvironmentType.GROUND: 
            {
                player.IsSwimming = true;
                break;
            } 
            
            case EnvironmentType.WATER: 
            {
                player.IsSwimming = false;
                break;
            }

            case EnvironmentType.LAVA: break;   // TODO
        }
    }
}
