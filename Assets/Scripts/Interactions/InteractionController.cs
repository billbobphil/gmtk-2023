using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        protected bool checkKeys()
        {
            return interactionKeyCodes.Any(code => Input.GetKeyDown(code));
        }
        
    }
}
