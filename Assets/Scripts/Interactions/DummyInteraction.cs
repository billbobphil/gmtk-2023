using UnityEngine;

namespace Interactions
{
    public class DummyInteraction : Interactable 
    {
        [SerializeField] private string somethingUnique;
        
        protected override void RunInteraction()
        {
            Debug.Log($"I have been interacted with : {somethingUnique}");
        }

        public override void MarkAsCurrentInteractable()
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        public override void UnMarkAsCurrentInteractable()
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}