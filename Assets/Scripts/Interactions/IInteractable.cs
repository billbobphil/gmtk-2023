using UnityEngine;

namespace Interactions
{
    public interface IInteractable
    {
        void Interact();
        void MarkAsCurrentInteractable();
        void UnMarkAsCurrentInteractable();
    }
}