using Dialog;
using UnityEngine;
using Util;

namespace Interactions
{
    public class DialogInteractable : InteractableWithNotice
    {
        [SerializeField] private Conversation _conversation;

        protected override void RunInteraction()
        {
            ConversationManager conversationManager =
                GameObject.FindWithTag("ConversationManager").GetComponent<ConversationManager>();
            
            conversationManager.SetConversation(_conversation);
            conversationManager.StartConversation();
        }
    }
}