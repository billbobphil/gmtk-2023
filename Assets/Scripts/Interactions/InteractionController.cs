using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class InteractionController : MonoBehaviour // TO-DO modularize t-dogs stuff
    {
        [SerializeField] protected List<KeyCode> interactionKeyCodes;
        protected bool _isInteracting;
        
        protected void PreventInteractions()
        {
            _isInteracting = true;
        }

        protected void EnableInteractions()
        {
            _isInteracting = false;
        }
        
    }
}
