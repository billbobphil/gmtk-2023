using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

namespace Interactions
{
    public class Triggerable : InteractionController
    {
        public int resetTimeSeconds = 3;
        private void Update()
        {
            if(!_isInteracting && interactionKeyCodes.Any(code => Input.GetKeyDown(code)))
            {
                if (_isTriggered)
                {
                    Debug.Log("HIT!");
                }
                else
                {
                    Debug.Log("Miss!");
                }
                PreventInteractions();
                Invoke("EnableInteractions", resetTimeSeconds); //TO-DO if I have time
            }
        }

        private bool _isTriggered = false;
        private void OnTriggerEnter2D(Collider2D other)
        {
            _isTriggered = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _isTriggered = false;
        }
    }
}
