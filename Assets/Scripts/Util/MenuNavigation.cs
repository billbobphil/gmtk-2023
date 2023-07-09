using Interactions;
using UnityEngine;

namespace Util
{
    public class MenuNavigation : MonoBehaviour
    {
        [SerializeField] private SceneInteractable overworldScene;
        [SerializeField] private SceneInteractable menuScene;
        [SerializeField] private SceneInteractable tutorialScene;
        [SerializeField] private SceneInteractable creditsScene;

        public void GoToOverworldZero()
        {
            overworldScene.Interact();
        }

        public void GoToMenu()
        {
            menuScene.Interact();
        }

        public void GoToCredits()
        {
            creditsScene.Interact();
        }

        public void GoToTutorial()
        {
            tutorialScene.Interact();
        }
    }
}
