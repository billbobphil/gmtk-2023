using Interactions;
using UnityEngine;

namespace Util
{
    public class MenuNavigation : MonoBehaviour
    {
        [SerializeField] private SceneInteractable overworldScene;

        public void GoToOverworldZero()
        {
            overworldScene.Interact();
        }
    }
}
