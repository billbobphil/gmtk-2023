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
        private string _playerName = "Takeout-Terry";
        [SerializeField] private string OtherName;
        [SerializeField] private Sprite otherPortrait;

        public List<Dialog> GetConversationSequence()
        {
            return conversationSequence;
        }

        public string GetPlayerName()
        {
            return _playerName;
        }

        public string GetOtherName()
        {
            return OtherName;
        }

        public Sprite GetOtherPortrait()
        {
            return otherPortrait;
        }
    }
}