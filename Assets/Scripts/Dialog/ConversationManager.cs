using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace Dialog
{
    public class ConversationManager : MonoBehaviour
    {
        private Conversation currentConversation;
        [SerializeField] private List<KeyCode> conversationAdvanceKeyCodes;
        private int conversationIndex;
        private bool isConversatonActive;
        [SerializeField] private GameObject conversationCanvas;
        [SerializeField] private GameObject playerDialogBox;
        [SerializeField] private GameObject otherDialogBox;
        [SerializeField] private TextMeshProUGUI playerText;
        [SerializeField] private TextMeshProUGUI otherText;
        [SerializeField] private TextMeshProUGUI playerNameText;
        [SerializeField] private TextMeshProUGUI otherNameText;
        [SerializeField] private Image otherPortrait;
        public AudioSource audiosource;

        private void Awake()
        {
            conversationCanvas.SetActive(false);
        }
        
        public void SetConversation(Conversation conversation)
        {
            currentConversation = conversation;
        }
        
        public void StartConversation()
        {
            conversationIndex = 0;
            PauseManager.Pause();
            conversationCanvas.SetActive(true);
            playerDialogBox.SetActive(false);
            otherDialogBox.SetActive(false);
            DisplayConversationStep();
            isConversatonActive = true;
            otherNameText.text = currentConversation.GetOtherName();
            playerNameText.text = currentConversation.GetPlayerName();
            otherPortrait.sprite = currentConversation.GetOtherPortrait();
        }
        
        private void Update()
        {
            if (!isConversatonActive) return;
            
            if (conversationAdvanceKeyCodes.Any((code => Input.GetKeyDown(code))))
            {
                conversationIndex++;

                if (conversationIndex >= currentConversation.GetConversationSequence().Count)
                {
                    EndConversation();
                }
                else
                {
                    DisplayConversationStep();
                }
            }
        }
        
        private void DisplayConversationStep()
        {
            Dialog currentStep = currentConversation.GetConversationSequence()[conversationIndex];
            audiosource.Play();
            if (currentStep.GetActor() == DialogActors.Player)
            {
                playerDialogBox.SetActive(true);
                otherDialogBox.SetActive(false);
                playerText.text = currentStep.GetMessage();
            }
            else if (currentStep.GetActor() == DialogActors.Other)
            {
                playerDialogBox.SetActive(false);
                otherDialogBox.SetActive(true);
                otherText.text = currentStep.GetMessage();
            }
        }

        private void EndConversation()
        {
            PauseManager.Resume();
            conversationCanvas.SetActive(false);
            isConversatonActive = false;
            conversationIndex = 0;
        }
    }
}