using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public static UnityAction PlayerInteractionStarted;
        public static UnityAction PlayerInteractionEnded;
        public void Interact()
        {
            PlayerInteractionStarted?.Invoke();
            RunInteraction();
            PlayerInteractionEnded?.Invoke();
        }
        protected abstract void RunInteraction();
        public abstract void MarkAsCurrentInteractable();
        public abstract void UnMarkAsCurrentInteractable();
    }
}