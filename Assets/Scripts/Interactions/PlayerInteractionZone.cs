using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactions
{
    public class PlayerInteractionZone : MonoBehaviour
    {
        [SerializeField] private PlayerInteractionController playerInteractionController;
        [SerializeField] private Vector3 interactionCircleScale;

        private void Awake()
        {
            transform.localScale = interactionCircleScale;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            
            if (interactable is null) return;
            
            playerInteractionController.InteractablesWithinRange.Add(interactable);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable is null) return;

            interactable.UnMarkAsCurrentInteractable();
            playerInteractionController.InteractablesWithinRange.Remove(interactable);
        }
    }
}
