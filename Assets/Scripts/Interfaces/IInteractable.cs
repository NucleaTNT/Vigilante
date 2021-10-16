using UnityEngine.InputSystem;

namespace Dev.NucleaTNT.Vigilante.Interfaces
{
    public interface IInteractable
    {
        // Ideally, all interactions should use the new InputSystem
        // However it can always just be called with ctx as null
        void Interact(InputAction.CallbackContext ctx);
    }
}