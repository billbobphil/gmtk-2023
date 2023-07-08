using UnityEngine;
using System.Linq;
using Interactions;
using Unity.VisualScripting;


namespace Minigame
{
    public class Triggerable : InteractionController
    {
        public int resetTimeSeconds = 3;
        private void Update()
        {
            if(!_isInteracting && checkKeys())
            {
                if (_isTriggered)
                {
                    Trigger();
                }
                else
                {
                    Debug.Log("Miss!");
                }
                PreventInteractions();
                Invoke("EnableInteractions", resetTimeSeconds); //TO-DO if I have time
            }
        }

        protected virtual void Trigger()
        {
            Debug.Log("Hit!");
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
