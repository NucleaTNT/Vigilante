using UnityEngine.InputSystem;

namespace Dev.NucleaTNT.Vigilante.Interfaces
{
    public interface IInteractable
    {
        void Interact(InputAction.CallbackContext ctx);
    }
}