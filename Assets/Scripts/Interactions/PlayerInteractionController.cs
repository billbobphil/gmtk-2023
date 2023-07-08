using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public class PlayerInteractionController : MonoBehaviour
    {
        
        public List<Interactable> InteractablesWithinRange;
        private bool _isInteracting;
        [SerializeField] private List<KeyCode> interactionKeyCodes;
        private Interactable _closestInteractableWithinRange;

        private void OnEnable()
        {
            Interactable.PlayerInteractionStarted += PreventInteractions;
            Interactable.PlayerInteractionEnded += EnableInteractions;
        }

        private void OnDisable()
        {
            Interactable.PlayerInteractionStarted -= PreventInteractions;
            Interactable.PlayerInteractionEnded -= EnableInteractions;
        }

        private void Awake()
        {
            InteractablesWithinRange = new List<Interactable>();
        }

        private void PreventInteractions()
        {
            _isInteracting = true;
        }

        private void EnableInteractions()
        {
            _isInteracting = false;
        }

        private void Update()
        {
            if (_isInteracting) return;
            
            FindClosestTarget();

            if (InteractablesWithinRange.Count > 0 && interactionKeyCodes.Any(code => Input.GetKeyDown(code)))
            {
                _closestInteractableWithinRange.Interact();
            }
        }

        private void FindClosestTarget()
        {
            if (InteractablesWithinRange.Count == 0)
            {
                _closestInteractableWithinRange = null;
                return;
            }

            int indexOfClosestTarget = 0;
            float closestDistanceSqr = Mathf.Infinity;
            Vector2 currentPosition = transform.position;

            for(int i = 0; i < InteractablesWithinRange.Count; i++)
            {
                Transform interactable = InteractablesWithinRange[i].transform;
                Vector2 directionToTarget = (Vector2)interactable.position - currentPosition;
                float distanceSquaredToTarget = directionToTarget.sqrMagnitude;
                if (distanceSquaredToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = distanceSquaredToTarget;
                    indexOfClosestTarget = i;
                }
            }

            for (int i = 0; i < InteractablesWithinRange.Count; i++)
            {
                if (i == indexOfClosestTarget)
                {
                    Interactable closestInteractable = InteractablesWithinRange[i];
                    if (_closestInteractableWithinRange != closestInteractable)
                    {
                        closestInteractable.MarkAsCurrentInteractable();
                        _closestInteractableWithinRange = closestInteractable;
                    }
                }
                else
                {
                    InteractablesWithinRange[i].UnMarkAsCurrentInteractable();
                }
            }
        }
    }
}