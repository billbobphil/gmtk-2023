using UnityEngine;

namespace Interactions
{
    public abstract class InteractableWithNotice : Interactable
    {
        [SerializeField] private InteractionNotice _notice;

        public override void MarkAsCurrentInteractable()
        {
            _notice.Show();
        }

        public override void UnMarkAsCurrentInteractable()
        {
            _notice.Hide();
        }
    }
}