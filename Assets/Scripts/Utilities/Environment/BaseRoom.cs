using UnityEngine;

public class BaseRoom : MonoBehaviour
{
    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) virtualCamera.SetActive(true);
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) virtualCamera.SetActive(false);
    }
}
