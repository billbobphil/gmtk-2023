using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Util;

namespace Dialog
{
    public class Conversation : MonoBehaviour
    {
        [SerializeField] private List<Dialog> conversationSequence;

        public List<Dialog> GetConversationSequence()
        {
            return conversationSequence;
        }
    }
}