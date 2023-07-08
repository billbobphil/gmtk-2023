using UnityEngine;

namespace Interactions
{
    public class DialogInteractable : InteractableWithNotice
    {
        protected override void RunInteraction()
        {
            Debug.Log("Here is my cool text!");
        }
    }
}